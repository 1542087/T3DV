package hcb.t3dv;

import java.util.List;

public interface IGenericRepository<T> {
	List<T> getAll() throws Exception;
	List<T> getList(ISpecification spec) throws Exception;
	T getSingle(ISpecification spec) throws Exception;
	T add(T item) throws Exception;
	T update(T item) throws Exception;
	void remove(T item) throws Exception;
	
	interface ISpecification {}
}
