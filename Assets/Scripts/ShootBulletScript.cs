using UnityEngine;
using System.Collections;

public class ShootBulletScript : MonoBehaviour {

    public float speed = 10;
    private CounteringScript counteringScript;
    private Transform camera;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);

        counteringScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CounteringScript>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform;
    }
	
    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    
}
