using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : HealthScript
{
    public GameObject Mask;
    public GameObject eyeLeft;
    public GameObject eyeRight;

    // Use this for initialization
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Death()
    {
        gameObject.transform.parent = null;
        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        GetComponent<EnemyScipt>().Active = false;

        Destroy(eyeLeft);
        Destroy(eyeRight);

        if(! Mask.GetComponent<HealthScript>().Dead)
        {
            Mask.GetComponent<HealthScript>().Death();
        }
    }
}
