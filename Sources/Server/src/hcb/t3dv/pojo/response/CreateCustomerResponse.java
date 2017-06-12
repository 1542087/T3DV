package hcb.t3dv.pojo.response;

import hcb.t3dv.bus.data.CreateCustomerData;
import hcb.t3dv.pojo.BaseResponse;

public class CreateCustomerResponse extends BaseResponse {

	public final CreateCustomerData data;
	
	public CreateCustomerResponse(boolean success, String message, CreateCustomerData data) {
		super(success, message);
		this.data = data;
	}
}
