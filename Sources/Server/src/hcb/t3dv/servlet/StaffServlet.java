package hcb.t3dv.servlet;

import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import hcb.t3dv.pojo.staff.AuthRequest;
import hcb.t3dv.pojo.staff.AuthResponse;
import hcb.t3dv.pojo.staff.CreateCustomerRequest;
import hcb.t3dv.pojo.staff.CreateCustomerResponse;
import hcb.t3dv.pojo.staff.GetCustomersRequest;
import hcb.t3dv.pojo.staff.GetCustomersResponse;

@Path("staff")
public class StaffServlet {

	@POST
	@Path("auth")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public AuthResponse authentication(AuthRequest req) {
		return null;
	}
	
	@GET
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
