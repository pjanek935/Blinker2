using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    private bool playerInside = false;
    public SwitchAction action;
	
	// Update is called once per frame
	void Update () {
        if (playerInside && Input.GetKeyDown(KeyCode.F))
            action.Action();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            playerInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            playerInside = false;
    }
}
