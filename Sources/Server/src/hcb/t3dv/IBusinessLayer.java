package hcb.t3dv;

import java.util.List;

import hcb.t3dv.pojo.Todo;

public interface IBusinessLayer {

	interface ITodoBusiness extends IBusinessLayer {
		List<Todo> getAllTodos();
		Todo getTodoById(String id);
		void addTodo(Todo todo);
		void updateTodo(Todo todo);
		void removeTodo(Todo todo);
	}
	
}
