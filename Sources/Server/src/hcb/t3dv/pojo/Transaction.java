package hcb.t3dv.pojo;

import hcb.t3dv.dao.ModelCustomer;
import hcb.t3dv.dao.ModelTransaction;

public class Transaction {
	protected String transactionID;
	protected String date;
	protected float balance;
	protected float amount;
	
	public String getTransactionID() {
		return transactionID;
	}
	public void setTransactionID(String transactionID) {
		this.transactionID = transactionID;
	}
	public String getDate() {
		return date;
	}
	public void setDate(String date) {
		this.date = date;
	}
	public float getBalance() {
		return balance;
	}
	public void setBalance(float balance) {
		this.balance = balance;
	}
	public float getAmount() {
		return amount;
	}
	public void setAmount(float amount) {
		this.amount = amount;
	}
	
	public ModelTransaction toModel(Staff staff, Customer customer) {
		ModelTransaction mTransaction = new ModelTransaction();
		mTransaction.transactionID = transactionID;
		mTransaction.date = date;
		mTransaction.balance = balance;
		mTransaction.amount = amount;
		ModelCustomer mCustomer = customer.toModel(staff);
		mTransaction.setCustomer(mCustomer);
		return mTransaction;
	}
}
