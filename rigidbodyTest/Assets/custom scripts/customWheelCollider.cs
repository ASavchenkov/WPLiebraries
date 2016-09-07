using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;

public class customWheelCollider : MonoBehaviour
{ 

    Dictionary<string, List<Collision>> collisionDictionary = new Dictionary<string, List<Collision>>();
    Rigidbody parentRB;
    public PlayerIndex idx;
    void Start()
    {
        parentRB = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        //col.contacts[0].thisCollider.GetComponentInChildren<wheelInfo>().COF); // this is the correct way to retrieve wheel info
        GamePadState state = GamePad.GetState(idx);
        float leftTorque = state.ThumbSticks.Left.Y * 20;
        float rightTorque = state.ThumbSticks.Right.Y * 20;//get the supposed torques we are meant to apply to each side
        foreach (KeyValuePair<string, List<Collision>> chainedWheels in collisionDictionary)
        {
            List<Collision> wheels = chainedWheels.Value;
            foreach(Collision col in wheels)
            {
                
                if(col.contacts[0].thisCollider.transform.parent.name=="leftSide") parentRB.AddForceAtPosition(parentRB.transform.forward*leftTorque,col.contacts[0].point);
                else if (col.contacts[0].thisCollider.transform.parent.name == "rightSide") parentRB.AddForceAtPosition(parentRB.transform.forward * rightTorque, col.contacts[0].point);

                //START DOING FRICTION
                float curCOF = col.contacts[0].thisCollider.GetComponent<wheelInfo>().COF;
                float downForce = col.impulse.y;
                float wheelSlip = parentRB.transform.InverseTransformDirection(parentRB.GetPointVelocity(col.contacts[0].point)).x;
                float outputFriction = 0;
                //start building the friction curve, or in this case set of lines
                if (wheelSlip > 0.2) outputFriction = downForce*curCOF;
                else if (wheelSlip < -0.2) outputFriction = -downForce*curCOF;
                else outputFriction = -downForce*curCOF*wheelSlip*5;
                //sprint(curCOF + "   " + wheelSlip + "   " + downForce + "   " + outputFriction);

                parentRB.AddForceAtPosition(parentRB.transform.right*outputFriction,col.contacts[0].point);
                

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