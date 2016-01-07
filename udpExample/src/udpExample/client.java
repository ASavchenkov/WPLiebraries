package udpExample;

import java.io.*;
import java.net.*;
import java.util.*;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

public class client {
	 public static void main(String args[]) throws Exception 
	 {
		 BufferedReader textIn = new BufferedReader(new InputStreamReader(System.in));
		 DatagramSocket clientSock = new DatagramSocket();
		 InetAddress thisIP = InetAddress.getLocalHost();
		 byte[] rx = new byte[1024];
		 byte[] tx = new byte[1024];
		while(true) {
		 System.out.println("What to is a");
		 Integer a = Integer.parseInt(textIn.readLine());
		 System.out.println("What to is b");
		 Integer b = Integer.parseInt(textIn.readLine());
		 JSONObject toSend = new JSONObject();
		 toSend.put("a", a);
		 toSend.put("b", b);
		 System.out.println(toSend.toJSONString());
		 tx = toSend.toJSONString().getBytes();
		 DatagramPacket sendTo = new DatagramPacket(tx,tx.length,thisIP,1235);
		 clientSock.send(sendTo);
		 String rxString;
		 do {
		 DatagramPacket receiveFrom = new DatagramPacket(rx, rx.length);
		 clientSock.receive(receiveFrom);
		 rxString = new String(receiveFrom.getData(), 0, receiveFrom.getLength());
		 }while(!rxString.contains(":"));
		 JSONParser parser = new JSONParser();
			Object out=parser.parse(rxString);
			JSONObject jsonObject = (JSONObject) out;
			System.out.println(jsonObject.get("c"));
		 if (a==-1) {
			 System.out.println("done");
				break;
			 }
	 }
		clientSock.close();
	 }
}