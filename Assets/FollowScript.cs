using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour {

    public Transform target;
    public float deltaX = 0;
    public float deltaY = 0;
    public float deltaZ = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = target.position + new Vector3(deltaX, deltaY, deltaZ);
	}
}
