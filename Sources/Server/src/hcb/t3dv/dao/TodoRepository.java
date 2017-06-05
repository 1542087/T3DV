package hcb.t3dv.dao;

import java.util.ArrayList;
import java.util.List;

import hcb.t3dv.App;
import hcb.t3dv.IGenericRepository;
import hcb.t3dv.bus.TodoSpecification;
import hcb.t3dv.pojo.Todo;

public class TodoRepository implements IGenericRepository<Todo> {

	@Override
	public List<Todo> getAll() {
		return new ArrayList<>(App.mData);
	}

	@Override
	public List<Todo> getList(IGenericRepository.ISpecification spec) {
		return null;
	}

	@Override
	public Todo getSingle(IGenericRepository.ISpecification spec) {
		TodoSpecification todoSpec = (TodoSpecification) spec;
		for(Todo todo : App.mData) {
			if(todo.getId().equals(todoSpec.id())) return todo;
		}
		return null;
	}

	@Override
	public void add(Todo item) {
		App.mData.add(item);
	}

	@Override
	public void update(Todo item) {
	}

	@Override
	public void remove(Todo item) {
	}
}
