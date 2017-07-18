using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Opens path in tutorial scene
public class WallOpenScript : MonoBehaviour {

    public TargetScript targetSctipt;

	// Update is called once per frame
	void Update () {
        if (targetSctipt.GetTargetHit() >= 3)
        {
            this.gameObject.SetActive(false);
        }
	}
}
