using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleCarController : MonoBehaviour
{
    public SideInfo leftSideInfo;
    public SideInfo rightSideInfo;
    public float maxMotorTorque; // maximum torque the motor can apply to wheel



    public void FixedUpdate()
    {
       // float throttle= Input.GetAxis("Vertical");
       // float steering = Input.GetAxis("Horizontal");
        
        float leftTorque = Input.GetAxis("leftTank") *maxMotorTorque;
        float rightTorque = Input.GetAxis("rightTank") * maxMotorTorque;

        //print(leftTorque + "   " + rightTorque);
        print(leftSideInfo.frontWheel.rpm + "   " + rightSideInfo.frontWheel.rpm);

        leftSideInfo.setTorque(leftTorque);
        rightSideInfo.setTorque(rightTorque);
        
    }
}

[System.Serializable]
public class SideInfo
{
    public WheelCollider frontWheel;
    public WheelCollider midWheel;
    public WheelCollider rearWheel;
    
    public bool chained; // are these wheels chained together?

    public void setTorque(float torque)
    {
        frontWheel.motorTorque = torque;
        //midWheel.motorTorque = torque;
        rearWheel.motorTorque = torque;
    }
}