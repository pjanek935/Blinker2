﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootUp : MonoBehaviour {

    private Rigidbody rb;
    private BlinkingScript blinkingScript;
    private SlowMotion slowMotion;

	// Use this for initialization
	void Start () {
        rb = transform.parent.gameObject.GetComponent<Rigidbody>();
        blinkingScript = transform.parent.gameObject.GetComponent<BlinkingScript>();
        slowMotion = transform.parent.gameObject.GetComponent<SlowMotion>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (blinkingScript.IsBlinking() && other.gameObject.tag == "NPC")
            Shoot();

    }

    void OnCollisionEnter(Collision other)
    {
        if (blinkingScript.IsBlinking() && other.gameObject.tag == "NPC")
            Shoot();
    }

    private void Shoot()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * 350, ForceMode.Impulse);
        transform.parent.GetComponent<FPSMovementScript>().Ground();
        blinkingScript.StopBlinking();
        slowMotion.startSlowMotion();
    }
}