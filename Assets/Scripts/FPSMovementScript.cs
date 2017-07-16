using UnityEngine;
using System.Collections;

public class FPSMovementScript : MonoBehaviour {

    public float moveSpeed = 25.0f;
    public float jumpPower = 100;

    private AnimationManagerScript animManager;
    private Rigidbody rb;
    private ShootingScript shootingScript;
    private SlowMotion slowMotion;
    private ThrowingScript throwingScript;

    private bool grounded = true;
    private bool hasJumped = false;
    private int maxJumps = 2;
    private int jumpCounter = 0;
    private bool canJump = true;
    private float horMove;
    private float verMove;

    // Use this for initialization
    void Start() {
        animManager = GetComponent<AnimationManagerScript>();
        shootingScript = GetComponent<ShootingScript>();
        slowMotion = GetComponent<SlowMotion>();
        throwingScript = GetComponent<ThrowingScript>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && canJump)
            hasJumped = true;

        if (jumpCounter >= maxJumps)
            canJump = false;
        else
            canJump = true;
    }

    void FixedUpdate() {
        horMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(horMove, 0, verMove);
        float speed = new Vector2(horMove, verMove).magnitude;
        if (grounded)
            animManager.Move(speed);
        else
            animManager.Move(0);

        if (hasJumped)
        {
            hasJumped = false;
            grounded = false;
            jumpCounter++;
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.up * jumpPower * (slowMotion.IsSlowMotion() ? 2 : 1));
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.tag == "Environment" || other.gameObject.tag == "Wall" ||
            other.gameObject.tag == "NPC") && !grounded)
            Ground();
    }

    public void Ground()
    {
        grounded = true;
        jumpCounter = 0;
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
