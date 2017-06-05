package hcb.t3dv.pojo;

import hcb.t3dv.dao.ModelCustomer;

public class Customer {
	protected String id;
	protected String accountID;
	protected String personalID;
	protected String name;
	protected String phone;
	protected String address;
	protected String birthday;
	protected Float balance;
	
	public String getId() {
		return id;
	}
	public void setId(String id) {
		this.id = id;
	}
	public String getAccountID() {
		return accountID;
	}
	public void setAccountID(String accountID) {
		this.accountID = accountID;
	}
	public String getPersonalID() {
		return personalID;
	}
	public void setPersonalID(String personalID) {
		this.personalID = personalID;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getPhone() {
		return phone;
	}
	public void setPhone(String phone) {
		this.phone = phone;
	}
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
	}
	public String getBirthday() {
		return birthday;
	}
	public void setBirthday(String birthday) {
		this.birthday = birthday;
	}
	public Float getBalance() {
		return balance;
	}
	public void setBalance(Float balance) {
		this.balance = balance;
	}
	
	public ModelCustomer toModel(Staff staff) {
		ModelCustomer mCustomer = new ModelCustomer();
		mCustomer.id = id;
		mCustomer.accountID = accountID;
		mCustomer.personalID = personalID;
		mCustomer.name = name;
		mCustomer.phone = phone;
		mCustomer.address = address;
		mCustomer.birthday = birthday;
		mCustomer.balance = balance;
		mCustomer.setStaff(staff);
		return mCustomer;
	}
}
