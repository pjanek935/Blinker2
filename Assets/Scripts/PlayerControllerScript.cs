using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {


    public float speed;

	// Use this for initialization
	void Start () {
        speed = 6f;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.position = transform.position + movement;
        
    }

}
