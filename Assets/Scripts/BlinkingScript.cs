using UnityEngine;
using System.Collections;
using System;

public class BlinkingScript : MonoBehaviour {

    public GameObject playerPhantom;
    public float blinkSpeed = 100f;
    public float blinkLength = 20f;
    public float distToObstacleThreshold = 6f;
    public float slowMoDuration = 1f;
    public float slowMoWindow = 0.1f;
    public ChromaticAberration chromaticAberration;

    private AnimationManagerScript animManager;
    private Rigidbody rb;
    private GameObject blinkDestination;
    private ShootingScript shootingScript;
    private ThrowingScript throwingScript;
    private float currentBlinkgSpeed;
    private bool blinking = false;
    private bool startBlink = false;
    private Vector3 blinkDirection;
    private float timer = 0;
    private Vector3 playerVelocity = new Vector3(0, 0, 0);
    private bool attacking = false;
    private int currentAttack = 0;
    private float attackTimer = 0;
    private bool throwBlink = false;
    private float bulletTimeTimer = 0f;
    private bool canSlowMo = false;
    private bool slowmo = false;
    private float slowmoTimer = 0;

    // Use this for initialization
    void Start () {
        currentBlinkgSpeed = blinkSpeed;
        animManager = GetComponent<AnimationManagerScript>();
        shootingScript = GetComponent<ShootingScript>();
        throwingScript = GetComponent<ThrowingScript>();
        rb = GetComponent<Rigidbody>();
        blinkDestination = GameObject.Find("BlinkDestination");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2") && !blinking)
        {
            Blink();
        }

        if (blinking)
        {
            transform.position = Vector3.MoveTowards(transform.position, blinkDestination.transform.position, currentBlinkgSpeed * Time.deltaTime);
            //Debug.Log("blinking...");
            playerVelocity = playerVelocity - transform.position;
            //Debug.Log("velocity: " + playerVelocity);
            if (playerVelocity == Vector3.zero)
            {
                blinking = false;
                //anim.SetTrigger("normal");
                animManager.Normal();
            }
            playerVelocity = transform.position;
        }

        if (canSlowMo)
        {
            bulletTimeTimer += Time.deltaTime;
            //Debug.Log(bulletTimeTimer);
            if (bulletTimeTimer >= slowMoWindow)
            {
                canSlowMo = false;
                //Debug.Log("Cant slowmo now.");
            }
        }

        Vector3 rayDirection = blinkDestination.transform.position - transform.position;
        float rayLength = Vector3.Distance(transform.position, blinkDestination.transform.position);
        Debug.DrawRay(transform.position, rayDirection * rayLength);

        attackTimer += Time.deltaTime;
        if (attackTimer >= 1f)
        {
            attackTimer = 0;
            //attacking = false;
            currentAttack = 0;
        }

        if (slowmo)
        {
            slowmoTimer += Time.deltaTime;
            if (slowmoTimer >= slowMoDuration)
            {
                Time.timeScale = 1;
                Time.fixedDeltaTime = 0.02F;
                slowmo = false;
                chromaticAberration.ChromaticAbberation = 1;
            }
        }
    }

    public bool isBlinking()
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
        float hozMove = Input.GetAxisRaw("Horizontal");
        float verMove = Input.GetAxisRaw("Vertical");
        if (hozMove == 0 && verMove == 0)
        {
            return;
        }
        if (verMove == 1 && !throwingScript.IsThrown() && shootingScript.getShootTimer() > shootingScript.fireRate)
        {
            if (currentAttack == 0)
            {
                animManager.Attack(0);
                currentAttack++;
                attackTimer = 0;
            }
            else if (currentAttack == 1)
            {
                animManager.Attack(1);
                currentAttack++;
                attackTimer = 0;
            }
            else if (currentAttack == 2)
            {
                animManager.Attack(2);
                currentAttack = 0;
                attackTimer = 0;
            }
        }
        blinking = true;
        playerVelocity = transform.position;
        blinkDirection = transform.rotation * (new Vector3(hozMove, 0, verMove).normalized);
        blinkDestination.transform.position = transform.position + blinkDirection * blinkLength;

        playerPhantom.transform.position = transform.position;
        bulletTimeTimer = 0;
        canSlowMo = true;

        RaycastHit raycastHit;
        Vector3 rayDirection = blinkDestination.transform.position - transform.position;
        float rayLength = Vector3.Distance(transform.position, blinkDestination.transform.position);
        Ray ray = new Ray(transform.position, rayDirection);
        if (Physics.Raycast(ray, out raycastHit, rayLength))
        {
            if (raycastHit.collider.tag == "Environment" || raycastHit.collider.tag == "Wall")
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

    public bool isSlowMo()
    {
        return slowmo;
    }

    private void StopBlinking()
    {
        blinking = false;
        rb.useGravity = true;
        if (throwingScript.IsThrown() && throwBlink)
        {
            throwingScript.PickUp();
            throwBlink = false;
        }
    }

    public bool CanSlowMo()
    {
        return canSlowMo;
    }

    public void startSlowMo()
    {
        if (slowmo)
        {
            return;
        }
        chromaticAberration.ChromaticAbberation = 5;
        slowmo = true;
        slowmoTimer = 0;
        Time.timeScale = 0.4f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    void OnTriggerEnter(Collider other)
    {

        if (blinking && other.gameObject.tag == "NPC")
        {
            StopBlinking();
            ShootUp();
        }

        if (other.gameObject.tag == "BlinkDestination" && blinking)
        {
            StopBlinking();
        }

        
    }

    void OnCollisionEnter(Collision other)
    {

        if (blinking && other.gameObject.tag == "NPC")
        {
            StopBlinking();
            ShootUp();
        }

        if ((other.gameObject.tag == "Environment" || other.gameObject.tag == "Wall") && blinking)
        {
            StopBlinking();
        }

        

    }

    private void ShootUp()
    {
        rb.AddForce(Vector3.up * 500, ForceMode.Impulse);
        Debug.Log("ShootUp");
        startSlowMo();
    }
}
