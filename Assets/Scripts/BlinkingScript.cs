using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class BlinkingScript : MonoBehaviour, Controls {

    public GameObject playerPhantom; //Object left after blinking, for dodge-slowmo use
    public float blinkSpeed = 100f;
    public float blinkLength = 20f;
    public float distToObstacleThreshold = 6f; //When distance to obstacle is smaller blinkig is canceled
    public bool active = true;
    public float blinkRefreshRate = 0.002f;

    private Image blinkSlider; //GUI element representing blink bar
    private RigAnimationManager animManager;
    private Rigidbody rb;
    private GameObject blinkDestination;
    private ShootingScript shootingScript;
    private ThrowingScript throwingScript;
    private SlowMotion slowMotion;

    private float currentBlinkgSpeed;
    private bool blinking = false;
    private bool throwBlink = false;

    // Use this for initialization
    void Start () {
        currentBlinkgSpeed = blinkSpeed;
        animManager = GetComponent<RigAnimationManager>();
        shootingScript = GetComponent<ShootingScript>();
        throwingScript = GetComponent<ThrowingScript>();
        slowMotion = GetComponent<SlowMotion>();

        rb = GetComponent<Rigidbody>();
        blinkDestination = GameObject.Find("BlinkDestination");
        blinkSlider = GameObject.Find("BlinkSlider").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!active)
            return;

        if (Input.GetButtonDown("Fire2") && !blinking)
            Blink();

        //Move towards blink direction
        if (blinking)
            transform.position = Vector3.MoveTowards(transform.position,
                blinkDestination.transform.position, currentBlinkgSpeed * Time.deltaTime);

        //Refill blink slider
        if (blinkSlider.fillAmount < 1)
            blinkSlider.fillAmount += blinkRefreshRate;

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
        if (verMove >= 0.2 && !throwingScript.IsThrown() && animManager.GetState() != RigAnimationManager.State.COUNTER)
            animManager.Attack();

        blinking = true;
        rb.useGravity = false;
        Vector3 blinkDirection = transform.rotation * (new Vector3(horMove, 0, verMove).normalized);
        blinkDestination.transform.position = transform.position + blinkDirection * blinkLength;

        playerPhantom.transform.position = transform.position;

        slowMotion.EnableSlowMotion(); //Slowmotion when dodge succesfull enabled

        //Check if there are obstacles on blink path
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
                    StopBlinking();
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

    public bool IsActive()
    {
        return active;
    }

    public void SetActive(bool active)
    {
        this.active = active;
    }
}
