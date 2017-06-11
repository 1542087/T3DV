package hcb.t3dv.bus.data;

public class AuthData {

	public final String sessionID;
	public final String branch;
	public AuthData(String sessionID, String branch) {
		super();
		this.sessionID = sessionID;
		this.branch = branch;
	}
}
