package mainPackage;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.HashMap;
import java.util.Map;

import com.google.gson.Gson;

/*
 * @author Aleksandr Savchenkov
 */
public class Communicator implements Runnable{

	InetAddress simAddr; //dont initialize this because you cant
	DatagramSocket sock; //initialize this in constructor with correct port.
	
	byte[] sendBuf = new byte[1024];
	byte[] rcvBuf = new byte[1024];
	DatagramPacket rcvPacket = new DatagramPacket(rcvBuf, rcvBuf.length);
	
	int ownPort = -1;
	int simPort = -1;
	
	Gson gson = new Gson(); //use this to actually convert shit.
	
	Map rcvDataMap = new HashMap();
	//use this map to store all most current data from the sim.
	
	
	/*
	 * @param _ownPort is the port this app will send data from.
	 */
	public Communicator( int _simPort) throws IOException{
		
		simPort = _simPort;
		simAddr = InetAddress.getLoopbackAddress();
		sock = new DatagramSocket();
		ownPort = sock.getLocalPort();//we never really use this.
		
		
	}
	
	public void run(){
		while(true){
			try {
				sock.receive(rcvPacket); // blocks the thread till we get some packet.
				String rcvMsg = new String(rcvPacket.getData(),0,rcvPacket.getLength());//turns packet into string.
				rcvDataMap.putAll(gson.fromJson(rcvMsg, HashMap.class)); // put the data we got into the sensorData
				
			} catch (IOException e) {
				System.out.println("having trouble recieving data yo.");
				e.printStackTrace();
			}
		}
	}
	
	public void sendString(String msg) throws IOException{
		sendBuf = msg.getBytes();
		DatagramPacket sendPack = new DatagramPacket(sendBuf,sendBuf.length,simAddr,simPort);
		sock.send(sendPack);
	}
	
	public int getPort(){
		return ownPort;
	}
	
	public Object getValue(Object key){
		return rcvDataMap.get(key);
	}
}
