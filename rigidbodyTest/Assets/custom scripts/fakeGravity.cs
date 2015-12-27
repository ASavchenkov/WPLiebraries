using UnityEngine;
using System.Collections;

public class fakeGravity : MonoBehaviour {
    public float G;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().AddForce(-transform.up * G, ForceMode.Acceleration);
    }
}
