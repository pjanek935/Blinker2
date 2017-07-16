using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class BlinkingScript : MonoBehaviour {

    public Image blinkSlider;
    public GameObject playerPhantom;
    public float blinkSpeed = 100f;
    public float blinkLength = 20f;
    public float distToObstacleThreshold = 6f;

    private AnimationManagerScript animManager;
    private Rigidbody rb;
    private GameObject blinkDestination;
    private ShootingScript shootingScript;
    private ThrowingScript throwingScript;
    private SlowMotion slowMotion;

    private float currentBlinkgSpeed;
    private bool blinking = false;
    private bool startBlink = false;
    private Vector3 blinkDirection;
    private Vector3 playerVelocity = new Vector3(0, 0, 0);
    private bool attacking = false;
    private int currentAttack = 0;
    private float attackTimer = 0;
    private bool throwBlink = false;

    // Use this for initialization
    void Start () {
        currentBlinkgSpeed = blinkSpeed;
        animManager = GetComponent<AnimationManagerScript>();
        shootingScript = GetComponent<ShootingScript>();
        throwingScript = GetComponent<ThrowingScript>();
        slowMotion = GetComponent<SlowMotion>();

        rb = GetComponent<Rigidbody>();
        blinkDestination = GameObject.Find("BlinkDestination");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire2") && !blinking)
            Blink();

        if (blinking)
        {
            transform.position = Vector3.MoveTowards(transform.position, blinkDestination.transform.position, currentBlinkgSpeed * Time.deltaTime);
            playerVelocity = playerVelocity - transform.position;
            if (playerVelocity == Vector3.zero)
            {
                blinking = false;
                //animManager.Normal();
            }
            playerVelocity = transform.position;
        }

        Vector3 rayDirection = blinkDestination.transform.position - transform.position;
        float rayLength = Vector3.Distance(transform.position, blinkDestination.transform.position);
        Debug.DrawRay(transform.position, rayDirection * rayLength);

        attackTimer += Time.deltaTime;
        if (attackTimer >= 1f)
        {
            attackTimer = 0;
            currentAttack++;
            if (currentAttack >= 3)
                currentAttack = 0;
        }

        if (blinkSlider.fillAmount < 1)
        {
            blinkSlider.fillAmount += 0.01f;
        }

    }

    public bool IsBlinking()
    {
        return blinking;
    }

    public void BlinkToKatana(Transform katanaTransform)
    {
        currentBlinkgSpeed = 2 * blinkSpeed;
        blinkDestination.transform.position = katanaTransform.position + transform.up * 5 + katanaTransform.forward * 7;
        blinking = true;
        rb.useGravity = false;
        throwBlink = true;
    }

    void Blink()
    {
        currentBlinkgSpeed = blinkSpeed;
        float horMove = Input.GetAxisRaw("Horizontal");
        float verMove = Input.GetAxisRaw("Vertical");

        //No movement - no blink
        if (horMove == 0 && verMove == 0)
            return;

        if (blinkSlider.fillAmount < 0.33f)
        {
            blinkSlider.GetComponentInParent<BlinkImage>().BlinkRed();
            return;
        }
            

        blinkSlider.fillAmount -= 0.33f;

        //Attack animation
        if (verMove >= 0.2 && !throwingScript.IsThrown() && animManager.GetState() != AnimationManagerScript.State.COUNTER)
            animManager.Attack();

        blinking = true;
        rb.useGravity = false;
        playerVelocity = transform.position; //??
        blinkDirection = transform.rotation * (new Vector3(horMove, 0, verMove).normalized);
        blinkDestination.transform.position = transform.position + blinkDirection * blinkLength;

        playerPhantom.transform.position = transform.position;

        slowMotion.EnableSlowMotion();

        RaycastHit raycastHit;
        Vector3 rayDirection = blinkDestination.transform.position - transform.position;
        float rayLength = Vector3.Distance(transform.position, blinkDestination.transform.position);
        Ray ray = new Ray(transform.position, rayDirection);
        if (Physics.Raycast(ray, out raycastHit, rayLength))
        {
            if (raycastHit.collider.tag == "Wall")
            {
                blinkDestination.transform.position = raycastHit.point;
                float distToObstacle = Vector3.Distance(transform.position, blinkDestination.transform.position);
                if (distToObstacle < distToObstacleThreshold)
                {
                    StopBlinking();
                }
            }
        }
    }


    public void StopBlinking()
    {
        blinking = false;
        rb.useGravity = true;
        if (throwingScript.IsThrown() && throwBlink)
        {
            throwingScript.PickUp();
            throwBlink = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BlinkDestination" && blinking)
            StopBlinking();
    }

    void OnCollisionEnter(Collision other)
    {
        if ( (other.gameObject.tag == "Wall") && blinking)
            StopBlinking();
    }

    private void ShootUp()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * 500, ForceMode.Impulse);
        GetComponent<FPSMovementScript>().Ground();
        slowMotion.startSlowMotion();
    }
}
