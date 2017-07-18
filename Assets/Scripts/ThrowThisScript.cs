using UnityEngine;
using System.Collections;

public class ThrowThisScript : MonoBehaviour {

    public Transform baseObject;
    public float torqueForward = 0f;
    public float torqueRight = 0f;
    public float torqueUp = 0f;
    public float speed = 10f;
    public BladeCollisionScript bladeCollider;
    public SlowMotion slowMotion;
    public ThrowingScript throwingScript;
    public FPSMovementScript fpsMovement;

    private MeshRenderer meshRenderer;
    private Rigidbody rb;
    private BoxCollider boxColider;
    private bool throwing = false;
    private bool isThrown = false;
    private bool canStuck = true;

	// Use this for initialization
	void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        boxColider = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (throwing)
        {
            isThrown = true;
            rb.isKinematic = false;
            throwing = false;
            meshRenderer.enabled = true;
            boxColider.enabled = true;
            transform.position = baseObject.position + baseObject.forward * 5 + baseObject.right * 2;
            transform.rotation = baseObject.rotation;
            rb.AddForce(baseObject.forward * speed * (slowMotion.IsSlowMotion() ? 2 : 1));
            rb.AddTorque(transform.forward * torqueForward);
            rb.AddTorque(transform.right * torqueRight);
            rb.AddTorque(transform.up * torqueUp);
            bladeCollider.ResetStuck();
        }
    }

    public void ThrowThis()
    {
        throwing = true;
        canStuck = true;
        rb.AddForce(Vector3.zero);
        rb.AddTorque(Vector3.zero);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.tag + ", isThrown: " + isThrown + ", isStuck: " + bladeCollider.IsStuck());
        if (collision.collider.tag == "Player" && isThrown)
        {
            //Debug.Log("Player collision!");
            PickUp();
        }
        canStuck = false;
    }

   public bool GetCanStuck()
    {
        return canStuck;
    }

    public bool getIsThrown()
    {
        return isThrown;
    }

    public void PickUp()
    {
        meshRenderer.enabled = false;
        boxColider.enabled = false;
        isThrown = false;
        //fpsMovement.ResetJumpCounter();
        
    }

    public void Freeze()
    {
        rb.AddForce(Vector3.zero);
        rb.AddTorque(Vector3.zero);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
    }

    public bool isStuck()
    {
        return bladeCollider.IsStuck();
    }
}
