package hcb.t3dv.pojo.response;

import hcb.t3dv.pojo.BaseResponse;
import hcb.t3dv.pojo.Customer;

public class GetCustomersResponse extends BaseResponse {
	
	public final Customer[] data;

	public GetCustomersResponse(boolean success, String message, Customer[] data) {
		super(success, message);
		this.data = data;
	}
	
}
