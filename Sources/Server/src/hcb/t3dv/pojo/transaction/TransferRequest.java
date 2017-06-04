package hcb.t3dv.pojo.transaction;

import hcb.t3dv.pojo.BaseRequest;

public class TransferRequest extends BaseRequest {
	public String receiver;
	public String sender;
	public float amount;
}
