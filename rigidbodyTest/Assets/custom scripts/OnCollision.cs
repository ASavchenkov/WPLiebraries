using UnityEngine;
using System.Collections;

public class OnCollision : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        print("enter called  "+ col.impactForceSum);
    }
}
