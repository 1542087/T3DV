package hcb.t3dv.dao;

import java.util.ArrayList;
import java.util.List;

import hcb.t3dv.App;
import hcb.t3dv.IGenericDataRepository;
import hcb.t3dv.bus.TodoSpecification;
import hcb.t3dv.pojo.Todo;

public class TodoRepository implements IGenericDataRepository<Todo> {

	@Override
	public List<Todo> getAll() {
		return new ArrayList<>(App.mData);
	}

	@Override
	public List<Todo> getList(IGenericDataRepository.Specification spec) {
		return null;
	}

	@Override
	public Todo getSingle(IGenericDataRepository.Specification spec) {
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
		// TODO Auto-generated method stub
	}

	@Override
	public void remove(Todo item) {
		// TODO Auto-generated method stub	
	}
}
