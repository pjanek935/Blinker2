using UnityEngine;
using System.Collections;

public class CameraControlScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 offset = new Vector3(horizontal/10, 0f, vertical/10);
        transform.position = transform.position + offset;
	}
}
