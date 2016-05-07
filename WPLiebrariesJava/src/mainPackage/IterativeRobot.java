package mainPackage;

import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

import com.google.gson.Gson;

public class IterativeRobot {
	
	private enum RobotState{
		DISABLED,
		ROBOT_INIT,
		AUTONOMOUS_INIT,
		AUTONOMOUS_PERIODIC,
		TELEOP_INIT,
		TELEOP_PERIODIC
	}
	
	static Communicator com;
	static Thread comThread;
	
	static Gson gson = new Gson();
	/**
	 * @param args
	 */
	public static void main(String[] args) {
		try {
			System.out.println("Attempting to take port: ");
			com = new Communicator(696);
		
			comThread = new Thread(com);
			comThread.start();
			
			RobotState curState = RobotState.DISABLED;
			
			Map robotHeader = new HashMap();
			robotHeader.put("variant", "WPLiebraries");
			robotHeader.put("port",com.getPort());
			
			
			String headerString = gson.toJson(robotHeader);
			
			
			while(true){
				
				/*
				 * regardless of state we want to keep updating the 
				 * header and sending it to the bot every 20 or so ms?
				 * (50 if theres actual important info in there)	
				 */
				
				try {
					com.sendString(headerString);
					System.out.println(com.getValue("port"));
				} catch (IOException e1) {
					System.out.println("yo having trouble communicating");
					e1.printStackTrace();
				}
				
				
				
				switch(curState){
				case DISABLED:
					break;
				
				}
				
				try {
					Thread.sleep(50);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				
				
			}
		
		} catch (IOException e) {
			System.out.println("failed to create Communicator");
			e.printStackTrace();
		}
		
	}
	
	public static void robotInit(){
		System.out.println("Users robotInit code running!");
	}
}
