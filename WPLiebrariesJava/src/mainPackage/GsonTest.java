package mainPackage;

import java.util.HashMap;
import java.util.Map;

import com.google.gson.Gson;

public class GsonTest {

	public static void main(String[] args) {
		
		Gson gson = new Gson();
		
		int[] vals = {34,43};
		
		String stuff = gson.toJson(vals);
		
		int[] newVals = gson.fromJson(stuff, int[].class);
		System.out.println(newVals[0] + "  " + newVals[1]);
	
		TestClass poop = new TestClass();
		
		System.out.println(gson.toJson(poop));
		
		Map m = new HashMap();
		Map header = new HashMap();
		
		header.put("version", "0.0.1");
		header.put("port", 3445);
		
		m.put("pot", 2.345);
		m.put("encoder", 34564);
		m.put("header", header);
		
		
		String msg = gson.toJson(m);
		
		Map newMap = new HashMap();
		
		newMap = gson.fromJson(msg, newMap.getClass());
		System.out.println(newMap.get("pot"));
		System.out.println(gson.toJson(newMap));
		
		
	}

}

