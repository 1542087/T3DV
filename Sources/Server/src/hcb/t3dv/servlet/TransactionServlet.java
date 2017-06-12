package hcb.t3dv.servlet;

import javax.ws.rs.Consumes;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import hcb.t3dv.Constant;
import hcb.t3dv.bus.CredentialChecker;
import hcb.t3dv.bus.TransactionBusiness;
import hcb.t3dv.bus.data.TransactionData;
import hcb.t3dv.dao.StaffRepository;
import hcb.t3dv.dao.TransactionRepository;
import hcb.t3dv.pojo.request.DepositRequest;
import hcb.t3dv.pojo.request.TransferRequest;
import hcb.t3dv.pojo.request.WithdrawRequest;
import hcb.t3dv.pojo.response.TransactionResponse;

@Path("transactions")
public class TransactionServlet {
	
	@POST
	@Path("transfer")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public TransactionResponse transfer(TransferRequest req) {
		StaffRepository staffRepository = new StaffRepository();
		CredentialChecker credentialChecker = new CredentialChecker(staffRepository);
		String staffID = credentialChecker.hasCredential(req.getSessionID());
		if(staffID == null)
			return new TransactionResponse(false, Constant.AUTH_FAILED, null);
		
		TransactionRepository transactionRepository = new TransactionRepository();
		TransactionBusiness business = new TransactionBusiness(transactionRepository);
		
		TransactionData transactionData = business.transfer(staffID, req.getData().getSender(), req.getData().getReceiver(), 
				req.getData().getAmount(), req.getData().getMessage());
		if(transactionData == null)
			return new TransactionResponse(false, business.errorMessage(), transactionData);
		return new TransactionResponse(true, "", transactionData);
	}
	
	@POST
	@Path("withdraw")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public TransactionResponse withdraw(WithdrawRequest req) {
		StaffRepository staffRepository = new StaffRepository();
		CredentialChecker credentialChecker = new CredentialChecker(staffRepository);
		String staffID = credentialChecker.hasCredential(req.getSessionID());
		if(staffID == null)
			return new TransactionResponse(false, Constant.AUTH_FAILED, null);
		
		TransactionRepository transactionRepository = new TransactionRepository();
		TransactionBusiness business = new TransactionBusiness(transactionRepository);
		
		TransactionData transactionData = business.withdraw(staffID, 
				req.getData().getCustomerID(), 
				req.getData().getAmount(), 
				req.getData().getMessage());
		if(transactionData == null)
			return new TransactionResponse(false, business.errorMessage(), transactionData);
		return new TransactionResponse(true, "", transactionData);
	}
	
	@POST
	@Path("deposit")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public TransactionResponse deposit(DepositRequest req) {
		StaffRepository staffRepository = new StaffRepository();
		CredentialChecker credentialChecker = new CredentialChecker(staffRepository);
		String staffID = credentialChecker.hasCredential(req.getSessionID());
		if(staffID == null)
			return new TransactionResponse(false, Constant.AUTH_FAILED, null);
		
		TransactionRepository transactionRepository = new TransactionRepository();
		TransactionBusiness business = new TransactionBusiness(transactionRepository);

		TransactionData transactionData = business.withdraw(staffID, 
				req.getData().getCustomerID(), 
				req.getData().getAmount(), 
				req.getData().getMessage());
		if(transactionData == null)
			return new TransactionResponse(false, business.errorMessage(), transactionData);
		return new TransactionResponse(true, "", transactionData);
	}
}
