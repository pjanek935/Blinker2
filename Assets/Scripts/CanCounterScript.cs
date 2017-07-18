using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Only for use in rig animation
public class CanCounterScript : MonoBehaviour {

    public CounteringScript counterigScript;

    public void CanCounter()
    {
        counterigScript.SetCanCounter(true);
    }
}
