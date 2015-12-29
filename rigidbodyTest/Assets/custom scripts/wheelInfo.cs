using UnityEngine;
using System.Collections;

public class wheelInfo : MonoBehaviour {

    public float COF; //coefficient of friction
    public float rotIntertia; //rotational inertia of wheel (mass isnt relevant here since we care about spinning
    float torque = 0;
    
    void Start(){
        torque = 0;
    }
    // Update is called once per frame
    void Update()
    {
        //todo, update torque variable here to be retrieved by custom wheelcollider script.
    }

    public float getTorque(){
        return(torque);
    }
}
