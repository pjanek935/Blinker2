using UnityEngine;
using System.Collections;

public class WallNoseScript : MonoBehaviour {

    public AnimationManagerScript animManager;
 
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Environment")
        {
            animManager.WallOn();
        }

    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Environment")
        {
            animManager.WallOf();
        }

    }

    


}
