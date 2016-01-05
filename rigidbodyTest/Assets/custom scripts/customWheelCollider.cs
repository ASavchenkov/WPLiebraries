using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class customWheelCollider : MonoBehaviour
{ 

    Dictionary<string, List<Collision>> collisionDictionary = new Dictionary<string, List<Collision>>();
    Rigidbody parentRB;

    void Start()
    {
        parentRB = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {

        //col.contacts[0].thisCollider.GetComponentInChildren<wheelInfo>().COF); // this is the correct way to retrieve wheel info

        float leftTorque = Input.GetAxis("leftTank") * 200;
        float rightTorque = Input.GetAxis("rightTank") * 200;//get the supposed torques we are meant to apply to each side

        foreach (KeyValuePair<string, List<Collision>> chainedWheels in collisionDictionary)
        {
            List<Collision> wheels = chainedWheels.Value;
            foreach(Collision col in wheels)
            {
                
                print(parentRB.transform.InverseTransformPoint(col.contacts[0].point).x + "  " + col.contacts[0].thisCollider.transform.parent.name);
                if(col.contacts[0].thisCollider.transform.parent.name=="leftSide") parentRB.AddForceAtPosition(parentRB.transform.forward*leftTorque,col.contacts[0].point);
                else if (col.contacts[0].thisCollider.transform.parent.name == "rightSide") parentRB.AddForceAtPosition(parentRB.transform.forward * rightTorque, col.contacts[0].point);

            }
            //            print(col.contacts[0].thisCollider.name);
        }
        //print(parentRB.velocity + "   " + parentRB.GetP);
        collisionDictionary.Clear();
    }

    void OnCollisionEnter(Collision col)
    {
        saveCollision(col);
    }
    void OnCollisionStay(Collision col)
    {
        saveCollision(col);
    }

    void saveCollision(Collision col)
    {
        
        if (col.contacts[0].thisCollider.transform.parent.parent.name == "wheels")
        {
            if (collisionDictionary.ContainsKey(col.contacts[0].thisCollider.transform.parent.name))
            {
                collisionDictionary[col.contacts[0].thisCollider.transform.parent.name].Add(col);
            }
            else
            {
                collisionDictionary.Add(col.contacts[0].thisCollider.transform.parent.name, new List<Collision> { col });
            }
        }
    }
}