package mainPackage;

import java.net.*;
import java.io.*;

public class TCPCommunicator {

	public static void main(String[] args) {

		try{
			Socket client = new Socket(InetAddress.getLoopbackAddress(),696);
			System.out.println("created client");
			
			OutputStream toServer = client.getOutputStream();
			DataOutputStream out = new DataOutputStream(toServer);
			
			while(true){
				out.writeUTF("AYYY LMAO");
					
			}
			
		}catch(Exception e){
			e.printStackTrace();
		}
		
	}

}
