using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class customWheelCollider : MonoBehaviour
{ 

    Dictionary<string, Collision> collisionDictionary = new Dictionary<string, Collision>();
    Rigidbody parentRB;

    void Start()
    {
        parentRB = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float leftTorque = Input.GetAxis("leftTank") * 20;
        float rightTorque = Input.GetAxis("rightTank") * 20;//get the supposed torques we are meant to apply to each side

        foreach (KeyValuePair<string,Collision> colPair in collisionDictionary)
        {
            Collision col = colPair.Value;
            //print(col.contacts[0].thisCollider.name);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.contacts[0].thisCollider.transform.parent.parent.name == "wheels") collisionDictionary[col.contacts[0].thisCollider.name] = col;
    }
    void OnCollisionStay(Collision col)
    {
        if(col.contacts[0].thisCollider.transform.parent.parent.name=="wheels") collisionDictionary[col.contacts[0].thisCollider.name] = col;
    }

    void saveCollision(Collision col)
    {
        //col.contacts[0].thisCollider.GetComponentInChildren<wheelInfo>().COF); // this is the correct way to retrieve wheel info

        

        //print(parentRB.velocity + "   " + parentRB.GetP);

    }
}