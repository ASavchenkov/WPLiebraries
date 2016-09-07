using System;
using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XInputDotNetPure;

public class CommunicationModule : MonoBehaviour {

	// Use this for initialization
    byte[] data = new byte[1024]; //this gets reassigned later so REALLY it doesnt matter what number you put in it.
    IPEndPoint ipep = new IPEndPoint(IPAddress.Loopback, 696);
    IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
    UdpClient newSock;
    public JObject currentData;
    public PlayerIndex[] joysticks;
	void Start ()
	{
	    
        newSock = new UdpClient(ipep);
	    newSock.Client.ReceiveTimeout = 100; //to keep unity from hanging
        print("setup socket with ep: " + ipep.ToString());

        //all this header stuff is going to go into the "currentData" JObject
        JObject header = new JObject();
        header.Add("version","0.0.1");
	    header.Add("port", ipep.Port);

        currentData = new JObject();
        currentData.Add("header",header);
        print(currentData.ToString());
	}
	
	// Update is called once per frame
	void Update ()
	{
	    
        putJoystickData();

	    try
	    {
	        print("trying to recieve");
	        data = newSock.Receive(ref sender);
	        print("recieved from: " + sender.ToString() + "this stuff: " + Encoding.ASCII.GetString(data));
	        string sendString = currentData.ToString();
	        print("sending: " + sendString);
	        byte[] sendBytes = Encoding.ASCII.GetBytes(sendString);
	        newSock.Send(sendBytes, sendBytes.Length, sender);
	    }
	    catch (Exception e)
	    {
	        print("timed out: " + e.StackTrace);
	        data = new byte[1];
	    }
	}

    void putJoystickData()
    {
        GamePadState[] padStates = new GamePadState[4];
        JArray JPadStates = new JArray();
        for (int i = 0; i < 4; i++)
        {
            padStates[i] = GamePad.GetState((PlayerIndex)i);
            JPadStates.Add(JObject.FromObject(padStates[i]));
        }
        currentData["Joysticks"] = JPadStates;
    }
}
