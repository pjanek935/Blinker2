using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {

    public GameObject text;
    public GameObject player;
    public Type type = Type.NONE;
    public static Transform lastTransform;

    public enum Type { ENABLE_BLINK, ENABLE_THROW, ENABLE_SHOOT, DISABLE_THROW, ENABLE_COUNTER, NONE}

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            lastTransform = this.transform;
            text.SetActive(true);
            switch (type)
            {
                case Type.ENABLE_BLINK:
                    player.GetComponent<BlinkingScript>().SetActive(true);
                    break;

                case Type.ENABLE_THROW:
                    player.GetComponent<ThrowingScript>().SetActive(true);
                    break;

                case Type.ENABLE_SHOOT:
                    player.GetComponent<ShootingScript>().SetActive(true);
                    break;

                case Type.DISABLE_THROW:
                    player.GetComponent<ThrowingScript>().SetActive(false);
                    break;

                case Type.ENABLE_COUNTER:
                    player.GetComponent<CounteringScript>().SetActive(true);
                    break;

                default:
                    break;
            }
        }
            
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            text.SetActive(false);
            
        }
            
    }
}
