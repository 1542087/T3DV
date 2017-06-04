package hcb.t3dv.servlet;

import javax.ws.rs.Consumes;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import hcb.t3dv.pojo.transaction.TransferRequest;
import hcb.t3dv.pojo.transaction.TransferResponse;
import hcb.t3dv.pojo.transaction.WithdrawRequest;
import hcb.t3dv.pojo.transaction.WithdrawResponse;

@Path("transactions")
public class TransactionServlet {
	
	@POST
	@Path("transfer")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public TransferResponse transfer(TransferRequest req) {
		return null;
	}
	
	@POST
	@Path("withdraw")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public WithdrawResponse withdraw(WithdrawRequest req) {
		return null;
	}
}
