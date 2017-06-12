package hcb.t3dv.bus;

import hcb.t3dv.bus.data.TransactionData;
import hcb.t3dv.dao.ModelCustomer;
import hcb.t3dv.dao.ModelTransaction;
import hcb.t3dv.dao.ModelTransaction.TRANSACTION;
import hcb.t3dv.dao.TransactionRepository;
import hcb.t3dv.pojo.Staff;
import hcb.t3dv.pojo.Transaction;

public class TransactionBusiness {
	
	private TransactionRepository repository;
	private String errMessage;
	
	public TransactionBusiness(TransactionRepository transactionRepository) {
		this.repository = transactionRepository;
	}
	
	public TransactionData deposite(String staffID, String customerID, float amount, String message) {	
		ModelTransaction transaction = build(staffID, customerID, amount, message);
		transaction.setType(TRANSACTION.DEPOSIT);
		
		return execute(transaction);
	}
	
	public TransactionData withdraw(String staffID, String customerID, float amount, String message) {
		ModelTransaction transaction = build(staffID, customerID, amount, message);
		transaction.setType(TRANSACTION.DEPOSIT);

		return execute(transaction);
	}
	
	public TransactionData transfer(String staffID, String customerID, String receiverID, float amount, String message) {
		ModelTransaction transaction = build(staffID, customerID, amount, message);
		transaction.setReceiver(receiverID);
		transaction.setType(TRANSACTION.DEPOSIT);

		return execute(transaction);
	}
	
	private ModelTransaction build(String staffID, String customerID, float amount, String message) {
		ModelCustomer customer = new ModelCustomer();
		customer.setId(customerID);
		Staff staff = new Staff(staffID, null, null);
		customer.setStaff(staff);
		
		ModelTransaction transaction = new ModelTransaction();
		transaction.setCustomer(customer);
		transaction.setAmount(amount);
		transaction.setMessage(message);
		
		return transaction;
	}
	
	private TransactionData execute(ModelTransaction transaction) {
		try {
			Transaction result = repository.add(transaction);
			return new TransactionData(result.getTransactionID(), result.getBalance(), result.getDate());
		} catch (Exception e) {
			e.printStackTrace();
			this.errMessage = e.getCause().getMessage();
		}
		return null;
	}
	
	public String errorMessage() {
		return errMessage;
	}
}
