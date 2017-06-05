package hcb.t3dv.dao;

import java.util.ArrayList;
import java.util.List;

import com.javonet.Javonet;
import com.javonet.JavonetException;
import com.javonet.api.NObject;

import hcb.t3dv.CSharpBridge;
import hcb.t3dv.IGenericRepository;
import hcb.t3dv.pojo.Customer;

public class CustomerRepository implements IGenericRepository<Customer> {
	
	private static final String DOMAIN = "BackEnd.KhachHangLogic";
	private static final String ACCOUNT_DOMAIN = "BackEnd.TaiKhoanLogic";

	@Override
	public List<Customer> getAll() {
		try {
			NObject[] result = CSharpBridge.plural(DOMAIN, "SearchAllCustomer");
			List<Customer> customers = new ArrayList<>();
			for (int i = 0; i < result.length; i++) {
				customers.add(parse(result[i]));
			}
			return customers;
		} catch (JavonetException e) {
			e.printStackTrace();
		}
		return null;
	}

	@Override
	public List<Customer> getList(ISpecification spec) {
		return null;
	}

	@Override
	public Customer getSingle(ISpecification spec) {
		// TODO given customer id, find account by customer ID method name
		try {
			NObject param = Javonet.New("CreditManagement.Models.KhachHang");
			param.set("MaKH", "customer id");
			NObject customerResult = CSharpBridge.single(DOMAIN, "SearchCustomerByCondition", param);
			
			Customer customer = parse(customerResult);
			
			NObject accountResult = CSharpBridge.single(ACCOUNT_DOMAIN, "", customer.getId());
			customer.setAccountID(accountResult.get("MaTK"));
			return customer;
		} catch (JavonetException e) {
			e.printStackTrace();
		}
		return null;
	}

	@Override
	public void add(Customer item) {
		try {
			NObject dtoCustomer = customer(item);
			NObject result1 = CSharpBridge.single(DOMAIN, "InsertCustomer", dtoCustomer);
			Boolean s1 = result1.get("success");
			if(s1) {
				NObject dtoAccount = account(item);
				NObject result2 = CSharpBridge.single(ACCOUNT_DOMAIN, "InsertAccount", dtoAccount);
				Boolean s2 = result2.get("success");
				// TODO return s1 & s2;
			}
		} catch (JavonetException e) {
			e.printStackTrace();
		}
	}

	@Override
	public void update(Customer item) {
		try {
			String accountID = item.getAccountID();
			if(accountID != null) {
				NObject updateBalance = updateBalance(item);	
				NObject result = CSharpBridge.single(ACCOUNT_DOMAIN, "UpdateAccount", updateBalance);
				Boolean success = result.get("success"); 
				if(success) {
					// TODO
				}
			}
		} catch (JavonetException e) {
			e.printStackTrace();
		}
	}

	@Override
	public void remove(Customer item) {
		
	}
	
	private Customer parse(NObject object) throws JavonetException {
		Customer customer = new Customer();
		customer.setId(object.get("MaKH"));
		customer.setName(object.get("TenKH"));
		customer.setPersonalID(object.get("cmnd"));
		customer.setAddress(object.get("DiaChi"));
		customer.setPhone(object.get("SoDienThoai"));
		customer.setBirthday(object.get("NgaySinh"));
		return customer;
	}
	
	private NObject customer(Customer customer) throws JavonetException {
		NObject param = Javonet.New("CreditManagement.Models.KhachHang");
		param.set("cmnd", customer.getPersonalID());
		param.set("TenKH", customer.getName());
		param.set("DiaChi", customer.getAddress());
		param.set("SoDienThoai", customer.getPhone());
		param.set("NgaySinh", customer.getBirthday());
		param.set("GioiTinh", "");
		return param;
	}
	
	private NObject account(Customer customer) throws JavonetException {
		ModelCustomer mCustomer = (ModelCustomer) customer;
		NObject param = Javonet.New("CCreditManagement.Models.TaiKhoan");
		param.set("MaKH", customer.getId());
		param.set("MaNV", mCustomer.refStaff._id);
		param.set("MaCN", mCustomer.refStaff.branch);
		return param;
	}
	
	private NObject updateBalance(Customer customer) throws JavonetException {
		// TODO create update account balance
		NObject param = Javonet.New("CCreditManagement.Models.TaiKhoan");
		param.set("MaTK", customer.getAccountID());
		param.set("SoDu", customer.getBalance());
		return param;
	}
}
