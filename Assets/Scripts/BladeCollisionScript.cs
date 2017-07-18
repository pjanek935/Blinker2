using UnityEngine;
using System.Collections;

public class BladeCollisionScript : MonoBehaviour {

    public Rigidbody rb;
    public ThrowThisScript throwKatanaScript;

    private bool collided = false;
    private bool stuck = false;

    public bool IsStuck()
    {
        return stuck;
    }

    public void ResetStuck()
    {
        stuck = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "Wall" && throwKatanaScript.GetCanStuck())
        {
            stuck = true;
            float magnitude = rb.velocity.magnitude;
            if (magnitude >= 6)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }
        }
    }
}
