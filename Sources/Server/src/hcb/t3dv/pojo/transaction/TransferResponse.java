package hcb.t3dv.pojo.transaction;

import hcb.t3dv.pojo.BaseResponse;
import hcb.t3dv.pojo.Transaction;

public class TransferResponse extends BaseResponse {
	
	private Transaction data;
	
	public Transaction getData() {
		return data;
	}

	public void setData(Transaction data) {
		this.data = data;
	}
}
