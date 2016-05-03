package auxTesting;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;
import java.net.SocketTimeoutException;

public class mainClass {

	public static void main(String[] args) throws IOException, InterruptedException 
	{
		//make it load different text files into the jsonobject for different types of robots
		//
		byte[] rcvBuf = new byte[65508];
		byte[] sendBuf = new byte[65508];
		DatagramSocket socket = new DatagramSocket(696);//create socket working with port 696
		InetAddress address = InetAddress.getLocalHost();
		DatagramPacket rcvPacket = new DatagramPacket(rcvBuf,rcvBuf.length); //create separate packets for recieving and sending
		
		DatagramPacket sendPacket = new DatagramPacket(sendBuf, sendBuf.length,address,2469);
		
		socket.setSoTimeout(200);//set timeout to 200 ms for the handshake part of the program
		
		boolean comms=false;
		while(!comms){
			String commsInitMessage = "sdfsdf";
			sendPacket = new DatagramPacket(commsInitMessage.getBytes(),commsInitMessage.length(),address,2469);
			socket.send(sendPacket);
			
			try{
				socket.receive(rcvPacket);
				String msg = new String(rcvPacket.getData(),"UTF-8");//make sure sim side is sending in UTF-8
				if(msg.equals("Robot Simulator Receiving.")){
					comms = true;
					System.out.println("comms established");
				}
			}catch(SocketTimeoutException e){
				System.out.println("");
			}
			
			}
		//now that a handshake has been established start both recieving and sending data
		socket.setSoTimeout(20);
		while(true){
			byte[] inBuffer = rcvPacket.getData();
			Thread.sleep(20);
			
		}
	}
	
	public void robotInit(){
		
	}
	
	public void disabledPeriodic(){
		
	}

}
