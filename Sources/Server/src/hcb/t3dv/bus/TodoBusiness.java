package hcb.t3dv.bus;

import java.util.List;

import hcb.t3dv.IBusinessLayer;
import hcb.t3dv.dao.TodoRepository;
import hcb.t3dv.pojo.Todo;

public class TodoBusiness implements IBusinessLayer.ITodoBusiness {
	
	private TodoRepository repository;
	
	public TodoBusiness(TodoRepository repository) {
		this.repository = repository;
	}

	@Override
	public List<Todo> getAllTodos() {
		return repository.getAll();
	}

	@Override
	public Todo getTodoById(String id) {
		TodoSpecification specification = new TodoSpecification.Builder().id(id).build();
		return repository.getSingle(specification);
	}

	@Override
	public void addTodo(Todo todo) {
		
	}

	@Override
	public void updateTodo(Todo todo) {
		
	}

	@Override
	public void removeTodo(Todo todo) {
		
	}
}
