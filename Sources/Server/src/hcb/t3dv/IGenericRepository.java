package hcb.t3dv;

import java.util.List;

public interface IGenericRepository<T> {
	List<T> getAll();
	List<T> getList(ISpecification spec);
	T getSingle(ISpecification spec);
	void add(T item);
	void update(T item);
	void remove(T item);
	
	interface ISpecification {}
}
