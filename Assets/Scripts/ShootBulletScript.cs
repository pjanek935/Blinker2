using UnityEngine;
using System.Collections;

public class ShootBulletScript : MonoBehaviour {

    public float speed = 10;
    private BlinkingScript blinkingScript;
    private CounteringScript counteringScript;
    private Transform camera;

    private Rigidbody rb;
    private bool canBeDestroyed = true;
    private int canDestroyCounter = 0;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        
        rb.AddForce(Quaternion.AngleAxis(90, transform.right) * transform.forward * speed);

        blinkingScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BlinkingScript>();
        counteringScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CounteringScript>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform;

    }
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerPhantom" && /*blinkingScript.isBlinking() &&*/ blinkingScript.CanSlowMo() && this.tag != "Bullet")
        {
            blinkingScript.startSlowMo();
        }
        if (other.tag == "PlayerFace" && counteringScript.CanCounter() && canBeDestroyed)
        {
            float speed = rb.velocity.magnitude;
            rb.velocity = (camera.forward + new Vector3(0, 0.1f, 0) ) * speed;
        }
        if (other.tag == "UndestroyableProjectile")
        {
            Destroy(this.gameObject);
        }
    }
}
