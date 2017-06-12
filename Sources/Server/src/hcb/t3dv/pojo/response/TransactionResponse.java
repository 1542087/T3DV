package hcb.t3dv.pojo.response;

import hcb.t3dv.bus.data.TransactionData;
import hcb.t3dv.pojo.BaseResponse;

public class TransactionResponse extends BaseResponse {
	
	public final TransactionData data;

	public TransactionResponse(boolean success, String message, TransactionData data) {
		super(success, message);
		this.data = data;
	}

}
