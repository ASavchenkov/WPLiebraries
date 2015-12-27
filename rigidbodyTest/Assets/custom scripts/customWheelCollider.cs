using UnityEngine;
using System.Collections;

public class customWheelCollider : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnCollisionEnter (Collision col){
        print("enter called  "+ this.gameObject.name + ":   " + col.impactForceSum + "   " + col.impulse + "   " + col.frictionForceSum);
    }
    void OnCollisionStay(Collision col){
        print(this.gameObject.name + ":   " + col.impactForceSum + "   " + col.impulse + "   " + col.frictionForceSum);
    }
}
