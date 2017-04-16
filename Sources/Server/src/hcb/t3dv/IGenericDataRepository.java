package hcb.t3dv;

import java.util.List;

public interface IGenericDataRepository<T> {
	List<T> getAll();
	List<T> getList(Specification spec);
	T getSingle(Specification spec);
	void add(T item);
	void update(T item);
	void remove(T item);
	
	interface Specification {}
}
