using UnityEngine;
using System.Collections;

public class CanCounterScript : MonoBehaviour {

    public CounteringScript counteringScript;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CanCounter()
    {
        counteringScript.SetCanCounter(true);
    }
}
