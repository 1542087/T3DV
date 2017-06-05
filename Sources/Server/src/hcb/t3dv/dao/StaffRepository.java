package hcb.t3dv.dao;

import java.util.List;

import com.javonet.JavonetException;
import com.javonet.api.NObject;

import hcb.t3dv.CSharpBridge;
import hcb.t3dv.IGenericRepository;
import hcb.t3dv.pojo.Staff;

public class StaffRepository implements IGenericRepository<Staff> {
	
	private final String DOMAIN = "BackEnd.UserLogic";

	@Override
	public List<Staff> getAll() {
		return null;
	}

	@Override
	public List<Staff> getList(ISpecification spec) {
		return null;
	}

	@Override
	public Staff getSingle(ISpecification spec) {
		try {
			SingleQuery singleQuery = ((Specification)spec).singleQuery();
			NObject bindingStaff = CSharpBridge.single(DOMAIN, "CheckLogin", singleQuery.id, singleQuery.password);
			return parse(bindingStaff);
		} catch (JavonetException e) {
			e.printStackTrace();
		}
		return null;
	}

	@Override
	public void add(Staff item) {
		
	}

	@Override
	public void update(Staff item) {
		
	}

	@Override
	public void remove(Staff item) {
		
	}
	
	public Staff parse(NObject object) throws JavonetException {
		return new Staff(object.get("MaNV"), object.get("cmnd"), object.get("CNTrucThuoc"));
	}
	
	public interface Specification {
		SingleQuery singleQuery();
		PluralQuery multipleQuery();
	}
	
	public static class SingleQuery {
		public final String id;
		public final String password;
		public SingleQuery(String id, String password) {
			this.id = id;
			this.password = password;
		}
	}
	
	public static class PluralQuery {
		
	}
}
