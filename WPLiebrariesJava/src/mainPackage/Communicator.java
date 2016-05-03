package mainPackage;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;


/*
 * @author Aleksandr Savchenkov
 */
public class Communicator {

	
	public Communicator(int ownPort, int simPort){
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
