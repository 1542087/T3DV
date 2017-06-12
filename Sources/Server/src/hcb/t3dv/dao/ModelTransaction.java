package hcb.t3dv.dao;

import hcb.t3dv.pojo.Transaction;

public class ModelTransaction extends Transaction {
	
	public enum TRANSACTION {DEPOSIT, WITHDRAW, TRANSFER};
	ModelCustomer customer;
	String receiver;
	TRANSACTION type;
	
	public void setCustomer(ModelCustomer customer) {
		this.customer = customer;
	}
	
	public void setType(TRANSACTION type) {
		this.type = type;
	}

	public void setReceiver(String receiver) {
		this.receiver = receiver;
	}
}
