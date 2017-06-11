package hcb.t3dv.pojo.transaction;

import hcb.t3dv.pojo.BaseResponse;
import hcb.t3dv.pojo.Transaction;

public class WithdrawResponse extends BaseResponse {
	
	public WithdrawResponse(boolean success, String message) {
		super(success, message);
		// TODO Auto-generated constructor stub
	}

	private Transaction data;
	
	public Transaction getData() {
		return data;
	}

	public void setData(Transaction data) {
		this.data = data;
	}
}
