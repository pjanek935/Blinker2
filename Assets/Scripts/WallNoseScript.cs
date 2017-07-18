using UnityEngine;
using System.Collections;

//Starts animation when nose hits obstacle
public class WallNoseScript : MonoBehaviour {

    public RigAnimationManager animManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Environment")
            animManager.WallOn();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Environment")
            animManager.WallOf();
    }

    


}
