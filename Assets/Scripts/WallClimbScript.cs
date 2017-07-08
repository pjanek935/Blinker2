using UnityEngine;
using System.Collections;

public class WallClimbScript : MonoBehaviour {

    public float climbingSpeed = 30f;
    public float maxClimbTime = 5;

    private bool touchingWall = false;
    private float wallClimbTimer = 0;
    private bool climbKeyDown = false;
    private bool climbing = false;

    private GameObject player;
    private Rigidbody rb;

    private int colCounter = 0;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Jump"))
        {
            climbKeyDown = true;
        }

        if (Input.GetButtonUp("Jump"))
        {
            climbKeyDown = false;
            wallClimbTimer = 0;
        }
    }

    void FixedUpdate()
    {
        if (climbKeyDown && touchingWall && wallClimbTimer <= maxClimbTime)
        {
            rb.AddForce(Vector3.zero);
            rb.velocity = Vector3.zero;
            player.transform.Translate(0, climbingSpeed * Time.deltaTime, 0);

            //player.transform.Translate(camera.transform.forward);
            wallClimbTimer += Time.deltaTime;
            climbing = true;
        }
        else
        {
            climbing = false;
        }
    }

    public bool isTouchingWall()
    {
        return touchingWall;
    }

    public bool isClimbing()
    {
        return climbing;
    }

    void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.tag == "Wall")
        {
            touchingWall = true;
            colCounter++;
        }

    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.tag == "Wall")
    //    {
    //        touchingWall = true;
    //    }
    //}

    //void OnCollisionExit(Collision collision)
    //{
    //    if (collision.collider.tag == "Wall")
    //    {
    //        touchingWall = true;
    //        wallClimbTimer = 0;
    //    }
    //}

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            //Debug.Log("wall exit!");
            colCounter--;
            if (colCounter <=0)
            {
                touchingWall = false;
                wallClimbTimer = 0;
            }
            
        }
    }


}
