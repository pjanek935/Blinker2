using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shoots player up and starts slowmo when player attacks enemy by sword
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

    void OnTriggerEnter(Collider other)
    {
        if (blinkingScript.IsBlinking() && other.gameObject.tag == "NPC")
        {
            Shoot();
            other.gameObject.GetComponent<NPCAI>().DisableCollider(0.1f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (blinkingScript.IsBlinking() && other.gameObject.tag == "NPC")
        {
            Shoot();
            other.gameObject.GetComponent<NPCAI>().DisableCollider(0.5f);
        }
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
