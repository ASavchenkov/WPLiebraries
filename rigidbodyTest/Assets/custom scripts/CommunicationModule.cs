using System;
using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class CommunicationModule : MonoBehaviour {

	// Use this for initialization
    byte[] data = new byte[1024]; //this gets reassigned later so REALLY it doesnt matter what number you put in it.
    IPEndPoint ipep = new IPEndPoint(IPAddress.Loopback, 696);
    IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
    UdpClient newSock;


	void Start () {
	    newSock = new UdpClient(ipep);
	    newSock.Client.ReceiveTimeout = 100; //to keep unity from hanging
        print("setup socket with ep: " + ipep.ToString());

    }
	
	// Update is called once per frame
	void Update () {
	    try{
            print("trying to recieve");
            data = newSock.Receive(ref sender);
        }
        catch (Exception e){
            print("timed out: " + e.StackTrace);
            data = new byte[1];
        }
	   
        
        print("recieved from: " + sender.ToString()+  "this stuff: " + Encoding.ASCII.GetString(data));

        print("sending: " + Encoding.ASCII.GetString(data));

        newSock.Send(data,data.Length,sender);
	}
}
