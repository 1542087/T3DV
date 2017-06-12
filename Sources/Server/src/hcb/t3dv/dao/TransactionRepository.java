package hcb.t3dv.dao;

import java.util.ArrayList;
import java.util.List;

import com.javonet.Javonet;
import com.javonet.JavonetException;
import com.javonet.api.NObject;

import hcb.t3dv.CSharpBridge;
import hcb.t3dv.Constant;
import hcb.t3dv.IGenericRepository;
import hcb.t3dv.pojo.Transaction;

public class TransactionRepository implements IGenericRepository<Transaction> {
	
	private static final String DOMAIN = "BackEnd.GiaoDichLogic";

	@Override
	public List<Transaction> getAll() {
		
		return null;
	}

	@Override
	public List<Transaction> getList(ISpecification spec) throws Exception {
		Specification specification = (Specification) spec;
		try {
			NObject query = buildQuery(specification.customerID());
			NObject result = CSharpBridge.single(DOMAIN, "SearchDealDetailByCondition", query);
			Boolean success = result.get(Constant.RESULT_OK);
			if(success) {
				NObject[] data = result.get(Constant.RESULT_DATA);
				List<Transaction> transactions = new ArrayList<>();
				for (NObject datum : data) {
					transactions.add(parse(datum));
				}
				return transactions;
			} else {
				throw new Exception((String) result.get(Constant.RESULT_MSG));
			}
		} catch (JavonetException e) {
			e.printStackTrace();
			throw new Exception(e.getCause().getMessage());
		}
	}

	@Override
	public Transaction getSingle(ISpecification spec) {
		return null;
	}

	@Override
	public Transaction add(Transaction item) throws Exception {
		try {
			ModelTransaction mTransaction = (ModelTransaction) item;
			NObject result = CSharpBridge.single(DOMAIN, "ThemMoiGiaoDich", mTransaction.customer.getId(),
					mTransaction.customer.refStaff._id,
					mTransaction.getAmount(),
					mTransaction.getMessage(),
					mTransaction.receiver,
					mTransaction.type.ordinal()+1);
			Boolean success = result.get(Constant.RESULT_OK);
			if(success) {
				NObject data = result.get(Constant.RESULT_DATA);
				Transaction transaction = new Transaction();
				transaction.setTransactionID(data.get("_magd"));
				transaction.setBalance(data.get("_sodu"));
				transaction.setAmount(mTransaction.getAmount());
				return transaction;
			} else {
				throw new Exception((String) result.get(Constant.RESULT_MSG));
			}
		} catch (JavonetException e) {
			e.printStackTrace();
			throw new Exception(e.getCause().getMessage());
		}
	}

	@Override
	public Transaction update(Transaction item) {
		return null;
	}

	@Override
	public void remove(Transaction item) {
		
	}
	
	private NObject buildQuery(String customerID) throws JavonetException {
		NObject query = Javonet.New("CreditManagement.Models.GiaoDich");
		query.set("MaKH", customerID);
		return query;
	}
	
	private Transaction parse(NObject objTransaction) throws JavonetException {
		Transaction transaction = new Transaction();
		transaction.setTransactionID(objTransaction.get("MaGD"));
		transaction.setAmount(objTransaction.get("SoTien"));
		transaction.setDate(objTransaction.get("NgayCapNhat"));
		return transaction;
	}
	
	public interface Specification extends ISpecification {
		String customerID();
	}
}
