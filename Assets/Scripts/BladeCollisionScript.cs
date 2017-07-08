using UnityEngine;
using System.Collections;

public class BladeCollisionScript : MonoBehaviour {

    public Rigidbody rb;
    public ThrowThisScript throwKatanaScript;

    private bool collided = false;
    private bool stuck = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (collided)
        {
            collided = false;
            stuck = true;
            float magnitude = rb.velocity.magnitude;
            //Debug.Log("Blade contact, " + magnitude + ", x: " + rb.velocity.x + ", y: " + rb.velocity.y + ", z: " + rb.velocity.z);
            if (magnitude >= 6)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }
        }
    }

    public bool IsStuck()
    {
        return stuck;
    }

    public void resetStuck()
    {
        stuck = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "Wall" && throwKatanaScript.GetCanStuck())
        {
            collided = true;
        }
    }
}
