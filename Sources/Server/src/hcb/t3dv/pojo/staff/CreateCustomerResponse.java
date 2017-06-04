package hcb.t3dv.pojo.staff;

import hcb.t3dv.pojo.BaseResponse;

public class CreateCustomerResponse extends BaseResponse {
	private Data data;
	
	public Data getData() {
		return data;
	}
	
	public void setData(Data data) {
		this.data = data;
	}

	public static class Data {
		private String customerID;

		public String getCustomerID() {
			return customerID;
		}

		public void setCustomerID(String customerID) {
			this.customerID = customerID;
		}
	}
}
