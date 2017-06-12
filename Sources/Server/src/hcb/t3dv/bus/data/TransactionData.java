package hcb.t3dv.bus.data;

public class TransactionData {

	public final String transactionID;
	public final String balance;
	public final String date;
	
	public TransactionData(String transactionID, String balance, String date) {
		this.transactionID = transactionID;
		this.balance = balance;
		this.date = date;
	}
}