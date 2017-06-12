package hcb.t3dv.pojo.request;

import hcb.t3dv.pojo.BaseRequest;

public class WithdrawRequest extends BaseRequest {
	
	protected Data data;
	
	public Data getData() {
		return data;
	}
	public void setData(Data data) {
		this.data = data;
	}

	public static class Data {
		private String customerID;
		private float amount;
		private String message;
		
		public String getCustomerID() {
			return customerID;
		}
		public void setCustomerID(String customerID) {
			this.customerID = customerID;
		}
		public float getAmount() {
			return amount;
		}
		public void setAmount(float amount) {
			this.amount = amount;
		}
		public String getMessage() {
			return message;
		}
		public void setMessage(String message) {
			this.message = message;
		}
	}
}