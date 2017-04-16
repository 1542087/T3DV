package hcb.t3dv.servlet;

import java.util.List;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import hcb.t3dv.bus.TodoBusiness;
import hcb.t3dv.dao.TodoRepository;
import hcb.t3dv.pojo.Todo;

@Path("todo")
public class TodoServlet {

	@GET
	@Path("all")
	@Produces(MediaType.APPLICATION_JSON)
	public List<Todo> getAllTodos() {
		TodoBusiness bus = new TodoBusiness(new TodoRepository());
		return bus.getAllTodos();
	}
	
	@GET
	@Path("{todo}")
	@Produces(MediaType.APPLICATION_JSON)
	public Todo getTodoById(@PathParam("todo") String id) {
		TodoBusiness bus = new TodoBusiness(new TodoRepository());
		return bus.getTodoById(id);
	}
}
