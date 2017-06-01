package hcb.t3dv;

import java.util.Arrays;
import java.util.List;

import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;

import com.javonet.Javonet;
import com.javonet.JavonetException;
import com.javonet.JavonetFramework;

import hcb.t3dv.pojo.Todo;

public class App implements ServletContextListener {
	public static final List<Todo> mData = Arrays.asList(
			new Todo("1", "abc", "bla bla bla"),
			new Todo("2", "def", "bla bla bla"),
			new Todo("3", "ghj", "bla bla bla"),
			new Todo("4", "lkj", "bla bla bla"),
			new Todo("5", "poi", "bla bla bla")
	);

	@Override
	public void contextDestroyed(ServletContextEvent arg0) {
		
	}

	@Override
	public void contextInitialized(ServletContextEvent evt) {
		importBackend();
	}
	
	private void importBackend() {
		try {
			Javonet.activate("mr.coixuong2011@gmail.com", "Yb4o-Gg23-g4C2-Zd85-Yi62", JavonetFramework.v40);
//			String backendResources = evt.getServletContext().getContextPath() + "/backend.dll";
			String backendResources = "D:/lastproject/ClassLibrary1.dll";
			Javonet.addReference(backendResources);
		} catch (JavonetException e) {
			e.printStackTrace();
		}
	}
}
