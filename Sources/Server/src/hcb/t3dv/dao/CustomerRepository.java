package hcb.t3dv.dao;

import java.util.ArrayList;
import java.util.List;

import com.javonet.Javonet;
import com.javonet.JavonetException;
import com.javonet.api.NObject;

import hcb.t3dv.CSharpBridge;
import hcb.t3dv.Constant;
import hcb.t3dv.IGenericRepository;
import hcb.t3dv.pojo.Customer;

public class CustomerRepository implements IGenericRepository<Customer> {
	
	private static final String DOMAIN = "BackEnd.KhachHangLogic";
	private static final String ACCOUNT_DOMAIN = "BackEnd.TaiKhoanLogic";

	@Override
	public List<Customer> getAll() throws Exception {
		try {
			NObject result = CSharpBridge.single(DOMAIN, "SearchAllCustomer");
			boolean success = result.get(Constant.RESULT_OK);
			if(success) {
				NObject[] nobjectCustomers = result.get(Constant.RESULT_DATA);
				List<Customer> customers = new ArrayList<>();
				for (int i = 0; i < nobjectCustomers.length; i++) {
					customers.add(parse(nobjectCustomers[i]));
				}
				return customers;
			} else {
				throw new Exception((String)result.get(Constant.RESULT_MSG));
			}
		} catch (JavonetException e) {
			e.printStackTrace();
			throw new Exception(e.getCause().getMessage());
		}
	}

	@Override
	public List<Customer> getList(ISpecification spec) {
		return null;
	}

	@Override
	public Customer getSingle(ISpecification spec) {
		// TODO given customer id, find account by customer ID method name
		try {
			NObject param = Javonet.New("CreditManagement.Models.KhachHang");
			param.set("MaKH", "customer id");
			NObject customerResult = CSharpBridge.single(DOMAIN, "SearchCustomerByCondition", param);
			
			Customer customer = parse(customerResult);
			
			NObject accountResult = CSharpBridge.single(ACCOUNT_DOMAIN, "", customer.getId());
			customer.setAccountID(accountResult.get("MaTK"));
			return customer;
		} catch (JavonetException e) {
			e.printStackTrace();
		}
		return null;
	}

	@Override
	public Customer add(Customer item) throws Exception {
		try {
			NObject dtoCustomer = customer(item);
			NObject result = CSharpBridge.single(DOMAIN, "InsertCustomer", dtoCustomer);
			Boolean success = result.get(Constant.RESULT_OK);
			if(success) {
				String customerID = result.get(Constant.RESULT_DATA);
				item.setId(customerID);
				return item;
			} else {
				throw new Exception((String) result.get(Constant.RESULT_MSG));
			}
		} catch (JavonetException e) {
			e.printStackTrace();
			throw new Exception(e.getCause().getMessage());
		}
	}

	@Override
	public Customer update(Customer item) throws Exception {
		try {
			String accountID = item.getAccountID();
			if(accountID != null) {
				NObject updateBalance = updateBalance(item);	
				NObject result = CSharpBridge.single(ACCOUNT_DOMAIN, "UpdateAccount", updateBalance);
				Boolean success = result.get(Constant.RESULT_OK); 
				if(success) {
					return (Customer)result.get(Constant.RESULT_DATA);
				} else {
					throw new Exception((String) result.get(Constant.RESULT_MSG));
				}
			} else {
				throw new IllegalArgumentException("accountID is missing");
			}
		} catch (JavonetException e) {
			e.printStackTrace();
			throw new Exception(e.getCause().getMessage());
		}
	}

	@Override
	public void remove(Customer item) {
		
	}
	
	private Customer parse(NObject object) throws JavonetException {
		Customer customer = new Customer();
		customer.setId(object.get("MaKH"));
		customer.setName(object.get("TenKH"));
		customer.setPersonalID(object.get("cmnd"));
		customer.setAddress(object.get("DiaChi"));
		customer.setPhone(object.get("SoDienThoai"));
		customer.setBirthday(object.get("NgaySinh"));
		return customer;
	}
	
	private NObject customer(Customer customer) throws JavonetException {
		NObject param = Javonet.New("CreditManagement.Models.KhachHang");
		param.set("cmnd", customer.getPersonalID());
		param.set("TenKH", customer.getName());
		param.set("DiaChi", customer.getAddress());
		param.set("SoDienThoai", customer.getPhone());
		param.set("NgaySinh", customer.getBirthday());
		param.set("GioiTinh", "");
		return param;
	}
	
	private NObject account(Customer customer) throws JavonetException {
		ModelCustomer mCustomer = (ModelCustomer) customer;
		NObject param = Javonet.New("CCreditManagement.Models.TaiKhoan");
		param.set("MaKH", customer.getId());
		param.set("MaNV", mCustomer.refStaff._id);
		param.set("MaCN", mCustomer.refStaff.branch);
		return param;
	}
	
	private NObject updateBalance(Customer customer) throws JavonetException {
		// TODO create update account balance
		NObject param = Javonet.New("CCreditManagement.Models.TaiKhoan");
		param.set("MaTK", customer.getAccountID());
		param.set("SoDu", customer.getBalance());
		return param;
	}
}
