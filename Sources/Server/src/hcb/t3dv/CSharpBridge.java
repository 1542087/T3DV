package hcb.t3dv;

import com.javonet.Javonet;
import com.javonet.JavonetException;
import com.javonet.api.NObject;

public class CSharpBridge {
	public static NObject single(String domain, String method, Object...params) throws JavonetException {
		NObject instance = Javonet.New(domain);
		return instance.invoke(method, params);
	}
	
	public static NObject single(String domain, String method) throws JavonetException {
		NObject instance = Javonet.New(domain);
		return instance.invoke(method);
	}
	
	public static NObject[] plural(String domain, String method, Object...params) throws JavonetException {
		NObject instance = Javonet.New(domain);
		return instance.invoke(method, params);
	}
	
	public static NObject[] plural(String domain, String method) throws JavonetException {
		NObject instance = Javonet.New(domain);
		return instance.invoke(method);
	}
}
