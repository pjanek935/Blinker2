using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Only for tartgets used in tutorial scene
public class TargetScript : MonoBehaviour {

    public static int targetHit;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.other.tag == "Bullet")
        {
            GetComponent<Rigidbody>().useGravity = true;
            targetHit++;
        }
    }

    public int GetTargetHit()
    {
        return targetHit;
    }
}
