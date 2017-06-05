package hcb.t3dv.dao;

import hcb.t3dv.pojo.Transaction;

public class ModelTransaction extends Transaction {
	
	ModelCustomer customer;
	
	public void setCustomer(ModelCustomer customer) {
		this.customer = customer;
	}
}
