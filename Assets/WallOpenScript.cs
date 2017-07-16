using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOpenScript : MonoBehaviour {

    public TargetScript targetSctipt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (targetSctipt.GetTargetHit() >= 3)
        {
            this.gameObject.SetActive(false);
        }
	}
}
