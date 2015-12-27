using UnityEngine;
using System.Collections;

public class customWheelCollider : MonoBehaviour {

    Collision currentCollision;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        print("running fake gravity");
        GetComponent<Rigidbody>().AddForce(-transform.up *(float)9.81, ForceMode.Acceleration);
	}
    void OnCollisionEnter (Collision col){
        currentCollision = col;
    }
    void OnCollisionStay(Collision col){
        currentCollision = col;    
    }
    void OnCollisionExit(Collision col)
    {
        currentCollision = null;
    }
}
