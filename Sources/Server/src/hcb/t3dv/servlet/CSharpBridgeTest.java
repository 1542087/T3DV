package hcb.t3dv.servlet;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import com.javonet.Javonet;
import com.javonet.JavonetException;
import com.javonet.api.NObject;

import hcb.t3dv.pojo.Dummy;

@Path("bridge")
public class CSharpBridgeTest {
	
	@GET
	@Path("dummy")
	@Produces(MediaType.APPLICATION_JSON)
	public Dummy tryout() {
		try {
			NObject bankingContext = Javonet.New("ClassLibrary1.TestCallDll");
			return new Dummy(bankingContext.invoke("MethodReturnString"));
		} catch (JavonetException e) {
			e.printStackTrace();
		}
		return new Dummy("failed");
	}
	
	@GET
	@Path("object")
	@Produces(MediaType.APPLICATION_JSON)
	public Dummy tryout2() {
		try {
			NObject bankingContext = Javonet.New("ClassLibrary1.TestCallDll");
			NObject whatever = bankingContext.invoke("MethodReturnObject");
			String data = (String)whatever.get("_string") + (int)whatever.get("_int");
			return new Dummy(data);
		} catch (JavonetException e) {
			e.printStackTrace();
		}
		return new Dummy("failed");
	}
	
	@GET
	@Path("objectarray")
	@Produces(MediaType.APPLICATION_JSON)
	public Dummy[] tryout3() {
		try {
			NObject bankingContext = Javonet.New("ClassLibrary1.TestCallDll");
			NObject whatever = bankingContext.invoke("MethodReturnWrapper");
			
			NObject[] objectArray = whatever.get("arrayOfObj");
			Dummy[] result = new Dummy[objectArray.length];
			for (int i = 0; i < result.length; i++) {
				String data = (String)objectArray[i].get("_string") + (int)objectArray[i].get("_int");
				result[i] = new Dummy(data);
			}
			return result;
		} catch (JavonetException e) {
			e.printStackTrace();
		}
		return new Dummy[0];
	}
}
