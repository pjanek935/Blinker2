using UnityEngine;
using System.Collections;

public class FPSMovementScript : MonoBehaviour {

    public float moveSpeed = 25.0f;
    public float jumpPower = 100;

    private AnimationManagerScript animManager;
    private Rigidbody rb;
    private ShootingScript shootingScript;
    private BlinkingScript blinkigScript;
    private ThrowingScript throwingScript;

    private bool grounded = true;
    private bool hasJumped = false;
    private int maxJumps = 2;
    private int jumpCounter = 0;
    private bool canJump = true;
    private float horMove;
    private float verMove;

    // Use this for initialization
    void Start () {
        animManager = GetComponent<AnimationManagerScript>();
        shootingScript = GetComponent<ShootingScript>();
        blinkigScript = GetComponent<BlinkingScript>();
        throwingScript = GetComponent<ThrowingScript>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
	
    void Update()
    {
        if (Input.GetButtonDown("Jump") && canJump)
        {
            hasJumped = true;
        }
        if (jumpCounter >= maxJumps)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }
	
	void FixedUpdate () {
        horMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(horMove, 0, verMove);
        if (!throwingScript.isThrowing() && shootingScript.getShootTimer() > shootingScript.fireRate)
        {
            animManager.move(verMove, horMove, grounded);
        }

        if (hasJumped)
        {
            hasJumped = false;
            grounded = false;
            jumpCounter++;
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.zero);
            rb.AddForce(transform.up * jumpPower * (blinkigScript.isSlowMo() ? 2 : 1));
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.tag == "Environment" || other.gameObject.tag == "Wall") && !grounded)
        {
            grounded = true;
            jumpCounter = 0;
        }
    }

    public void ResetJumpCounter()
    {
        jumpCounter = 0;
        Debug.Log("Reseting jump counter");
    }
    
    public float getVerMove()
    {
        return verMove;
    }

    public float getHorMove()
    {
        return horMove;
    }
}
