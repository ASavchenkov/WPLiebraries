package udpExample;

import java.io.*;
import java.net.*;
import java.util.*;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;
public class server {
	public static void main(String args[]) throws Exception 
	 {
		
		 DatagramSocket  serverSock = new DatagramSocket(1235);
		 byte[] rx = new byte[1024];
		 byte[] tx = new byte[1024];
		 while(true) {
			 DatagramPacket receivePacket = new DatagramPacket(rx, rx.length);
			 serverSock.receive(receivePacket);
			 
			 String rxString = new String(receivePacket.getData(), 0 , receivePacket.getLength());//also trims string
			 JSONParser parser = new JSONParser();
					Object obj=parser.parse(rxString);
					JSONObject jsonObject = (JSONObject) obj;
			System.out.println(rxString);	
			 
//			 JSONObject out = new JSONObject();
//			 out.put("c", 3);
//			 
//			 InetAddress ip = receivePacket.getAddress();
//			 int port = receivePacket.getPort();
//			 String txString = out.toJSONString();
//			 System.out.println(txString);
//			 tx = txString.getBytes();
//			 DatagramPacket sendPacket = new DatagramPacket(tx, tx.length,ip,port);
//			 serverSock.send(sendPacket);
			if (rxString.contains("-1")) {
				break;
			 }
		 }
		 serverSock.close();
		 System.out.println("ShutDown");
	 }

}
