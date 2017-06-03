package hcb.t3dv.pojo.staff;

import java.util.List;

import hcb.t3dv.pojo.BaseResponse;
import hcb.t3dv.pojo.Customer;

public class GetCustomersResponse extends BaseResponse {
	private List<Customer> data;

	public List<Customer> getData() {
		return data;
	}

	public void setData(List<Customer> data) {
		this.data = data;
	}
}
