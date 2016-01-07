package udpExample;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;


public class jsontest {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		JSONArray obj2 = new JSONArray();
		obj2.add("pneumatic");
		obj2.add(new Integer(3));
		System.out.println(obj2.toJSONString());
		JSONParser parser = new JSONParser();
		String out = obj2.toJSONString();
		try {
			Object obj=parser.parse(out);
			JSONArray array = (JSONArray)obj;
			System.out.println(array);
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
	}

}
