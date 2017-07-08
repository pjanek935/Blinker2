using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

    public Transform thrownKatana;
    public ThrowThisScript thrownKatanaScript;
    public MeshRenderer swordMesh;
    public Transform spawnPoint;
    public GameObject bullet;
    //public GameObject playerPhantom;
    //public float moveSpeed = 5.0f;
    //public float jumpPower = 100;
    //public float blinkSpeed = 100f;
    //public float blinkLength = 20f;
    //public float distToObstacleThreshold = 6f;
    //public float counterTime = 0.5f;
    //public float fireRate = 0.5f;
    //public float slowMoDuration = 1f;
    //public float slowMoWindow = 0.1f;

    //General
    private AnimationManagerScript animManager;
    private Rigidbody rb;
    private GameObject blinkDestination;

    private FPSMovementScript fpsMovementScript;
    //FPS Movement
    //private bool grounded = true;
    //private bool hasJumped = false;
    //private bool slower = false;
    //private int maxJumps = 2;
    //private int jumpCounter = 0;
    //private bool canJump = true;
    //private float hozMove;
    //private float verMove;

    //Blinking
    //private float currentBlinkgSpeed;
    //private bool blinking = false;
    //private bool startBlink = false;
    //private Vector3 blinkDirection;
    //private float timer = 0;
    //private Vector3 playerVelocity = new Vector3(0, 0, 0);
    //private bool attacking = false;
    //private int currentAttack = 0;
    //private float attackTimer = 0;
    //private bool throwBlink = false;
    //private float bulletTimeTimer = 0f;
    //private bool canSlowMo = false;
    //private bool slowmo = false;
    //private float slowmoTimer = 0;
    
    //Combat
    //private float counterTimer = 0;
    //private bool countering = false;
    //private bool throwing = false;
    //private bool canCounter = false;
    //private float nextFire = 0.0f;
    //private float shootTimer = 0;

    // Use this for initialization
    void Start () {
        animManager = GetComponent<AnimationManagerScript>();
        fpsMovementScript = GetComponent<FPSMovementScript>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        blinkDestination = GameObject.Find("BlinkDestination");
        //currentBlinkgSpeed = blinkSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        MovementUpdate();
        BlinkUpdate();
        CombatUpdate();
    }

    void FixedUpdate()
    {
        MovementFixedUpdate();
    }

    void OnCollisionEnter(Collision other)
    {
        //if ((other.gameObject.tag == "Environment" || other.gameObject.tag == "Wall") && !grounded)
        //{
        //    grounded = true;
        //    jumpCounter = 0;
        //}
        //if ((other.gameObject.tag == "Environment" || other.gameObject.tag == "Wall") && blinking)
        //{
        //    StopBlinking();
        //}

    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "BlinkDestination" && blinking)
        //{
        //    StopBlinking();
        //}

        //if (other.gameObject.tag == "Katana" && thrownKatanaScript.getIsThrown())
        //{
        //    thrownKatanaScript.PickUp();
        //    Debug.Log("!!!");
        //}
    }

    private void MovementFixedUpdate()
    {
        //hozMove = Input.GetAxis("Horizontal") * moveSpeed * (slower ? 0.2f : 1) * Time.deltaTime;
        //verMove = Input.GetAxis("Vertical") * moveSpeed * (slower ? 0.2f : 1) * Time.deltaTime;
        //transform.Translate(hozMove, 0, verMove);
        //if (!throwing && shootTimer > fireRate)
        //{
        //    animManager.move(verMove, hozMove, grounded);
        //}
        
        //if (hasJumped)
        //{
        //    hasJumped = false;
        //    grounded = false;
        //    jumpCounter++;
        //    rb.velocity = Vector3.zero;
        //    rb.AddForce(Vector3.zero);
        //    rb.AddForce(transform.up * jumpPower * (slowmo ? 2 : 1));
        //}
    }

    private void MovementUpdate()
    {
        //if (Input.GetButtonDown("Jump") && canJump)
        //{
        //    hasJumped = true;
        //}
        //if (jumpCounter >= maxJumps)
        //{
        //    canJump = false;
        //}
        //else
        //{
        //    canJump = true;
        //}
    }

    private void BlinkUpdate()
    {
        //if (Input.GetButtonDown("Fire2") && !blinking)
        //{
        //    Blink();
        //}
        //if (Input.GetKeyDown(KeyCode.LeftShift) && !thrownKatanaScript.getIsThrown())
        //{
        //    throwing = true;
        //    animManager.Throw();
        //}
        //if (Input.GetKeyDown(KeyCode.LeftShift) && thrownKatanaScript.getIsThrown())
        //{
        //    float d = Vector3.Distance(thrownKatana.transform.position, transform.position);
        //    if ( d < 10)
        //    {
        //        Debug.Log("Distance: " + d);
        //        thrownKatanaScript.PickUp();
        //    }
        //    else
        //    {
        //        BlinkToKatana();
        //    }

        //}

        //if (blinking)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, blinkDestination.transform.position, currentBlinkgSpeed * Time.deltaTime);
        //    //Debug.Log("blinking...");
        //    playerVelocity = playerVelocity - transform.position;
        //    Debug.Log("velocity: " + playerVelocity);
        //    if (playerVelocity == Vector3.zero)
        //    {
        //        blinking = false;
        //        //anim.SetTrigger("normal");
        //        animManager.Normal();
        //    }
        //    playerVelocity = transform.position;

        //    bulletTimeTimer += Time.deltaTime;
        //    if (bulletTimeTimer >= slowMoWindow)
        //    {
        //        canSlowMo = false;
        //    }
        //}

        //Vector3 rayDirection = blinkDestination.transform.position - transform.position;
        //float rayLength = Vector3.Distance(transform.position, blinkDestination.transform.position);
        //Debug.DrawRay(transform.position, rayDirection * rayLength);

        //attackTimer += Time.deltaTime;
        //if (attackTimer >= 1f)
        //{
        //    attackTimer = 0;
        //    //attacking = false;
        //    currentAttack = 0;

        //}

        //if (slowmo)
        //{
        //    slowmoTimer += Time.deltaTime;
        //    if (slowmoTimer >= slowMoDuration)
        //    {
        //        Time.timeScale = 1;
        //        Time.fixedDeltaTime = 0.02F;
        //        slowmo = false;
        //    }
        //}
    }

    //public bool isBlinking()
    //{
    //    return blinking;
    //}

    //private void BlinkToKatana()
    //{
    //    //thrownKatanaScript.Freeze();
    //    //Vector3 rayDirection = thrownKatana.position - transform.position;
    //    //Ray ray = new Ray(transform.position, rayDirection);
    //    //float rayLength = Vector3.Distance(transform.position, thrownKatana.position);
    //    //RaycastHit raycastHit;
    //    //if (Physics.Raycast(ray, out raycastHit, rayLength))
    //    //{
    //    //    if (raycastHit.collider.tag == "Wall")
    //    //    {
    //    //        transform.position = raycastHit.transform.position;
    //    //        return;
    //    //    }
    //    //}
    //    //transform.position = thrownKatana.position + transform.up * 5;

    //    currentBlinkgSpeed = 2 * blinkSpeed;
    //    thrownKatanaScript.Freeze();
    //    blinkDestination.transform.position = thrownKatana.position + transform.up * 5 + thrownKatana.forward * 7;
    //    blinking = true;
    //    rb.useGravity = false;
    //    throwBlink = true;

    //}

    //void Blink()
    //{
    //    currentBlinkgSpeed = blinkSpeed;
    //    float hozMove = Input.GetAxisRaw("Horizontal");
    //    float verMove = Input.GetAxisRaw("Vertical");
    //    if (hozMove == 0 && verMove == 0)
    //    {
    //        return;
    //    }
    //    if (verMove == 1 && !thrownKatanaScript.getIsThrown() && shootTimer > fireRate)
    //    {
    //        if (currentAttack == 0)
    //        {
    //            animManager.Attack(0);
    //            currentAttack++;
    //            attackTimer = 0;
    //        }
    //        else if (currentAttack == 1)
    //        {
    //            animManager.Attack(1);
    //            currentAttack++;
    //            attackTimer = 0;
    //        }
    //        else if (currentAttack == 2)
    //        {
    //            animManager.Attack(2);
    //            currentAttack = 0;
    //            attackTimer = 0;
    //        }
    //    }
    //    blinking = true;
    //    playerVelocity = transform.position;
    //    blinkDirection = transform.rotation * (new Vector3(hozMove, 0, verMove).normalized);
    //    blinkDestination.transform.position = transform.position + blinkDirection * blinkLength;

    //    playerPhantom.transform.position = transform.position;
    //    bulletTimeTimer = 0;
    //    canSlowMo = true;

    //    RaycastHit raycastHit;
    //    Vector3 rayDirection = blinkDestination.transform.position - transform.position;
    //    float rayLength = Vector3.Distance(transform.position, blinkDestination.transform.position);
    //    Ray ray = new Ray(transform.position, rayDirection);
    //    if (Physics.Raycast(ray, out raycastHit, rayLength))
    //    {
    //        if (raycastHit.collider.tag == "Environment" || raycastHit.collider.tag == "Wall")
    //        {
    //            blinkDestination.transform.position = raycastHit.point;
    //            float distToObstacle = Vector3.Distance(transform.position, blinkDestination.transform.position);
    //            if (distToObstacle < distToObstacleThreshold)
    //            {
    //                StopBlinking();
    //            }
    //        }
    //    }
    //}

    //public bool isSlowMo()
    //{
    //    return slowmo;
    //}

    private void CombatUpdate()
    {

        //shootTimer += Time.deltaTime;
        //if (countering)
        //{
        //    counterTimer += Time.deltaTime;
        //    if (counterTimer >= counterTime)
        //    {
        //        countering = false;
        //        counterTimer = 0;
        //        animManager.StopCounter();
        //        CanCounter(false);
        //    }
        //}

        //if (Input.GetButton("Fire1") && !countering && Time.time > nextFire)
        //{
        //    nextFire = Time.time + fireRate;
        //    shootTimer = 0;
        //    animManager.Shoot();
        //    GameObject bulletInstance = GameObject.Instantiate(bullet, spawnPoint.position, spawnPoint.rotation) as GameObject;
        //    Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody>();
        //    Vector3 additionalSpeed = new Vector3(fpsMovementScript.getHorMove()*moveSpeed, 0, fpsMovementScript.getVerMove()*moveSpeed);
        //    //bulletRb.velocity = bulletRb.velocity + additionalSpeed;
        //}
        //if (Input.GetKeyDown(KeyCode.E) && !countering && !thrownKatanaScript.getIsThrown())
        //{
        //    animManager.Counter();
        //    countering = true;
        //    counterTimer = 0;
        //}

        
    }

    //public void Throw()
    //{
    //    //throwing = true;
    //    swordMesh.enabled = false;
    //    thrownKatanaScript.ThrowThis();
    //    throwing = false;
    //}

    //public void PickUp()
    //{
    //    throwing = false;
    //    swordMesh.enabled = true;
    //    animManager.Normal();
    //}

    //private void StopBlinking()
    //{
    //    blinking = false;
    //    rb.useGravity = true;
    //    if (thrownKatanaScript.getIsThrown() && throwBlink)
    //    {
    //        thrownKatanaScript.PickUp();
    //        throwBlink = false;
    //    }
    //}

    //public bool CanSlowMo()
    //{
    //    return canSlowMo;
    //}

    //public void startSlowMo()
    //{
    //    if (slowmo)
    //    {
    //        return;
    //    }
    //    slowmo = true;
    //    slowmoTimer = 0;
    //    Time.timeScale = 0.4f;
    //    Time.fixedDeltaTime = 0.02F * Time.timeScale;

    //}

    //public void CanCounter(bool canCounter)
    //{
    //    this.canCounter = canCounter;
    //}

    //public bool GetCanCounter()
    //{
    //    return canCounter;
    //}
}
