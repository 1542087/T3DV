package hcb.t3dv.pojo.request;

import hcb.t3dv.pojo.BaseRequest;

public class TransferRequest extends BaseRequest {
	
	private Data data;
	
	public Data getData() {
		return data;
	}
	public void setData(Data data) {
		this.data = data;
	}

	public static class Data {
		private String receiver;
		private String sender;
		private float amount;
		private String message;
		
		public String getReceiver() {
			return receiver;
		}
		public void setReceiver(String receiver) {
			this.receiver = receiver;
		}
		public String getSender() {
			return sender;
		}
		public void setSender(String sender) {
			this.sender = sender;
		}
		public float getAmount() {
			return amount;
		}
		public void setAmount(float amount) {
			this.amount = amount;
		}
		public String getMessage() {
			return message;
		}
		public void setMessage(String message) {
			this.message = message;
		}
	}
}