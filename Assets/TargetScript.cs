using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

    public static int targetHit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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
