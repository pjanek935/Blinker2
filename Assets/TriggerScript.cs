using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {

    public GameObject text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            text.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            text.SetActive(false);
    }
}
