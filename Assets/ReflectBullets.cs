using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectBullets : MonoBehaviour {

    private CounteringScript counteringScript;
    private Transform camera;

    // Use this for initialization
    void Start () {
        counteringScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CounteringScript>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" && counteringScript.CanCounter())
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            float speed = rb.velocity.magnitude;
            rb.velocity = (camera.forward + new Vector3(0, 0.1f, 0)) * speed;
        }
    }
}
