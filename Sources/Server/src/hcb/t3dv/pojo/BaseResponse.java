package hcb.t3dv.pojo;

public class BaseResponse {
	public final boolean success;
	public final String message;
	
	public BaseResponse(boolean success, String message) {
		this.success = success;
		this.message = message;
	}
}