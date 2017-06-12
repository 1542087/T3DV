package hcb.t3dv.bus;

import java.util.List;

import hcb.t3dv.bus.data.AuthData;
import hcb.t3dv.bus.data.CreateCustomerData;
import hcb.t3dv.dao.CustomerRepository;
import hcb.t3dv.dao.StaffRepository;
import hcb.t3dv.dao.StaffRepository.PluralQuery;
import hcb.t3dv.dao.StaffRepository.SingleQuery;
import hcb.t3dv.pojo.Customer;
import hcb.t3dv.pojo.Staff;

public class StaffBusiness {
	
	private StaffRepository staffRepository;
	private CustomerRepository customerRepository;
	private String errMessage;
	
	public StaffBusiness(StaffRepository staffRepository, CustomerRepository customerRepository) {
		this.staffRepository = staffRepository;
		this.customerRepository = customerRepository;
	}
	
	public AuthData authentication(String uID, String pwd) {
		StaffRepository.Specification spec = new StaffRepository.Specification() {
			
			@Override
			public SingleQuery singleQuery() {
				return new StaffRepository.SingleQuery(uID, pwd);
			}
			
			@Override
			public PluralQuery multipleQuery() {
				return null;
			}
		};
		try {
			Staff staff = staffRepository.getSingle(spec);
			return new AuthData(staff._id + CredentialChecker.CREDENTIAL_SIGN + pwd, staff.branch);
		} catch (Exception e) {
			this.errMessage = e.getCause().getMessage();
			e.printStackTrace();
		}
		return null;
	}
	
	public CreateCustomerData createCustomer(String identification, String name, String address, 
			String phone, String birthday) {
		Customer customer = new Customer();
		customer.setPersonalID(identification);
		customer.setName(name);
		customer.setAddress(address);
		customer.setPhone(phone);
		customer.setBirthday(birthday);
		try {
			Customer createdCustomer = customerRepository.add(customer);
			return new CreateCustomerData(createdCustomer.getAccountID());
		} catch (Exception e) {
			this.errMessage = e.getCause().getMessage();
			e.printStackTrace();
		}
		return null;
	}

	public Customer[] getCustomers() {
		try {
			List<Customer> customers = customerRepository.getAll();
			return customers.toArray(new Customer[customers.size()]);
		} catch (Exception e) {
			this.errMessage = e.getCause().getMessage();
			e.printStackTrace();
		}
		return null;
	}
	
	public String errorMessage() {
		return this.errMessage;
	}
}
