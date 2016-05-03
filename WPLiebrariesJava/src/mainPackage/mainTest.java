package mainPackage;

import java.io.*;
import java.net.*;

public class mainTest {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		try {
			
			DatagramSocket sock = new DatagramSocket(3476);
			
			byte[] sendData = new byte[1024];
			byte[] recieveData = new byte[1024];
			
			String msg = "YO WASSSUP MOFO";
			
			InetAddress simAddr = InetAddress.getLoopbackAddress();
			
			sendData = msg.getBytes();
			
			while(true){
				DatagramPacket sendPacket = new DatagramPacket(sendData, sendData.length,simAddr,696);   
				
				sock.send(sendPacket);
				
				DatagramPacket rcvPacket = new DatagramPacket(recieveData, recieveData.length);
				
				sock.receive(rcvPacket);
				String response = new String(rcvPacket.getData());
				System.out.println(response);

				System.out.println();
			}			
			
			
		} catch (SocketException e) {
			e.printStackTrace();
		} catch (IOException e){
			e.printStackTrace();
		}
	}

}
