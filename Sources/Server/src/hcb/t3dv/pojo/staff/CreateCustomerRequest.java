package hcb.t3dv.pojo.staff;

import hcb.t3dv.pojo.BaseRequest;

public class CreateCustomerRequest extends BaseRequest {

	public Data data;
	
	public static class Data {
		public String id;
		public String name;
		public String address;
		public String phone;
		public String birthday;
		public String sex;
	}
}
