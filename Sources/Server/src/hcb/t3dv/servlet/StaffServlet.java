package hcb.t3dv.servlet;

import javax.ws.rs.Consumes;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import hcb.t3dv.Constant;
import hcb.t3dv.bus.CredentialChecker;
import hcb.t3dv.bus.StaffBusiness;
import hcb.t3dv.bus.data.AuthData;
import hcb.t3dv.bus.data.CreateCustomerData;
import hcb.t3dv.dao.CustomerRepository;
import hcb.t3dv.dao.StaffRepository;
import hcb.t3dv.pojo.Customer;
import hcb.t3dv.pojo.request.AuthRequest;
import hcb.t3dv.pojo.request.CreateCustomerRequest;
import hcb.t3dv.pojo.request.GetCustomersRequest;
import hcb.t3dv.pojo.response.AuthResponse;
import hcb.t3dv.pojo.response.CreateCustomerResponse;
import hcb.t3dv.pojo.response.GetCustomersResponse;

@Path("staff")
public class StaffServlet {

	@POST
	@Path("auth")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public AuthResponse authentication(AuthRequest req) {
		StaffRepository staffRepository = new StaffRepository();
		StaffBusiness staffBusiness = new StaffBusiness(staffRepository, null);
		AuthData authData = staffBusiness.authentication(req.getUserID(), req.getPassword());
		if(authData == null) {
			return new AuthResponse(false, staffBusiness.errorMessage(), null);
		}
		return new AuthResponse(true, "", authData);
	}
	
	@POST
	@Path("customers")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public GetCustomersResponse getCustomers(GetCustomersRequest req) {
		StaffRepository staffRepository = new StaffRepository();
		CredentialChecker credentialChecker = new CredentialChecker(staffRepository);
		String staffID = credentialChecker.hasCredential(req.getSessionID());
		if(staffID == null)
			return new GetCustomersResponse(false, Constant.AUTH_FAILED, null);
		
		CustomerRepository customerRepository = new CustomerRepository();
		StaffBusiness staffBusiness = new StaffBusiness(staffRepository, customerRepository);
		Customer[] customers = staffBusiness.getCustomers();
		if(customers == null)
			return new GetCustomersResponse(false, staffBusiness.errorMessage(), null);
		return new GetCustomersResponse(true, "", customers);
	}
	
	@POST
	@Path("newcustomer")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public CreateCustomerResponse newCustomer(CreateCustomerRequest req) {
		StaffRepository staffRepository = new StaffRepository();
		CredentialChecker credentialChecker = new CredentialChecker(staffRepository);
		String staffID = credentialChecker.hasCredential(req.getSessionID());
		if(staffID == null)
			return new CreateCustomerResponse(false, Constant.AUTH_FAILED, null);
		
		CustomerRepository customerRepository = new CustomerRepository();
		StaffBusiness staffBusiness = new StaffBusiness(staffRepository, customerRepository);
		CreateCustomerData createCustomerData = staffBusiness.createCustomer(
				req.getData().getIdentification(), 
				req.getData().getName(), 
				req.getData().getAddress(), 
				req.getData().getPhone(), 
				req.getData().getBirthday());
		if(createCustomerData == null)
			return new CreateCustomerResponse(false, staffBusiness.errorMessage(), null);
		return new CreateCustomerResponse(true, "", createCustomerData);
	}
}
