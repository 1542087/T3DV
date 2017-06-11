package hcb.t3dv.dao;

import java.util.List;

import com.javonet.JavonetException;
import com.javonet.api.NObject;

import hcb.t3dv.CSharpBridge;
import hcb.t3dv.Constant;
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
	public Staff getSingle(ISpecification spec) throws Exception {
		try {
			SingleQuery singleQuery = ((Specification)spec).singleQuery();
			NObject result = CSharpBridge.single(DOMAIN, "CheckLogin", singleQuery.id, singleQuery.password);
			boolean success = result.get(Constant.RESULT_OK);
			if(success) {
				return parse(result.get("_data"));
			} else {
				throw new Exception((String)result.get(Constant.RESULT_MSG));
			}
		} catch (JavonetException e) {
			e.printStackTrace();
			throw new Exception(e.getCause().getMessage());
		}
	}

	@Override
	public Staff add(Staff item) {
		return item;
	}

	@Override
	public Staff update(Staff item) {
		return item;
	}

	@Override
	public void remove(Staff item) {
		
	}
	
	public Staff parse(NObject object) throws JavonetException {
		return new Staff(object.get("MaNV"), object.get("cmnd"), object.get("CNTrucThuoc"));
	}
	
	public interface Specification extends ISpecification {
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
