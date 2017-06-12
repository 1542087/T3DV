package hcb.t3dv.bus;

import hcb.t3dv.dao.StaffRepository;
import hcb.t3dv.dao.StaffRepository.PluralQuery;
import hcb.t3dv.dao.StaffRepository.SingleQuery;
import hcb.t3dv.pojo.Staff;

public class CredentialChecker {
	
	public static final String CREDENTIAL_SIGN = ",";
	private StaffRepository staffRepository;
	
	public CredentialChecker(StaffRepository staffRepository) {
		this.staffRepository = staffRepository;
	}

	/**
	 * return staff id
	 * @param token
	 * @return
	 */
	public String hasCredential(String token) {
		String[] credentials = token.split(",");
		if(credentials.length == 2) {
			String userID = credentials[0];
			String pwd = credentials[1];
			StaffRepository.Specification spec = new StaffRepository.Specification() {
				
				@Override
				public SingleQuery singleQuery() {
					return new StaffRepository.SingleQuery(userID, pwd);
				}
				
				@Override
				public PluralQuery multipleQuery() {
					return null;
				}
			};
			try {
				Staff staff = staffRepository.getSingle(spec);
				return staff._id;
			} catch (Exception e) {
				e.printStackTrace();
			}
		}
		return null;
	}
	
}
