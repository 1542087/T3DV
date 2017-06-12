package hcb.t3dv.pojo.request;

import hcb.t3dv.pojo.BaseRequest;

public class CreateCustomerRequest extends BaseRequest {
	
	private Data data;
	
	public Data getData() {
		return data;
	}
	public void setData(Data data) {
		this.data = data;
	}

	public static class Data {
		
		private String identification;
		private String name;
		private String address;
		private String phone;
		private String birthday;
		
		public String getIdentification() {
			return identification;
		}
		public void setIdentification(String identification) {
			this.identification = identification;
		}
		public String getName() {
			return name;
		}
		public void setName(String name) {
			this.name = name;
		}
		public String getAddress() {
			return address;
		}
		public void setAddress(String address) {
			this.address = address;
		}
		public String getPhone() {
			return phone;
		}
		public void setPhone(String phone) {
			this.phone = phone;
		}
		public String getBirthday() {
			return birthday;
		}
		public void setBirthday(String birthday) {
			this.birthday = birthday;
		}
	}
}
