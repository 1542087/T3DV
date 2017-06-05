package hcb.t3dv.dao;

import hcb.t3dv.pojo.Customer;
import hcb.t3dv.pojo.Staff;

public class ModelCustomer extends Customer {
	
	Staff refStaff;
	
	public void setStaff(Staff staff) {
		this.refStaff = staff;
	}
}
