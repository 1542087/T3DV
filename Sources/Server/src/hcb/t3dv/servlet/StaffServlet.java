package hcb.t3dv.servlet;

import javax.ws.rs.Consumes;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

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
		return null;
	}
	
	@POST
	@Path("customers")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public GetCustomersResponse getCustomers(GetCustomersRequest req) {
		return null;
	}
	
	@POST
	@Path("newcustomer")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public CreateCustomerResponse newCustomer(CreateCustomerRequest req) {
		return null;
	}
}
