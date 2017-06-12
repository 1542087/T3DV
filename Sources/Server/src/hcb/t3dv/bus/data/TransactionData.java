package hcb.t3dv.bus.data;

public class TransactionData {

	public final String transactionID;
	public final float balance;
	public final String date;
	
	public TransactionData(String transactionID, float balance, String date) {
		this.transactionID = transactionID;
		this.balance = balance;
		this.date = date;
	}
}