package hcb.t3dv.pojo.response;

import hcb.t3dv.bus.data.AuthData;
import hcb.t3dv.pojo.BaseResponse;

public class AuthResponse extends BaseResponse {
	
	public final AuthData data;

	public AuthResponse(boolean success, String message, AuthData data) {
		super(success, message);
		this.data = data;
	}

}
