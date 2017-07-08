using UnityEngine;
using System.Collections;

public class CounteringScript : MonoBehaviour {

    public float counterTime = 0.5f;

    private AnimationManagerScript animManager;
    public ThrowingScript throwingScript;
    private float counterTimer = 0;
    private bool countering = false;
    private bool canCounter = false;

    // Use this for initialization
    void Start () {
        animManager = GetComponent<AnimationManagerScript>();
        throwingScript = GetComponent<ThrowingScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (countering)
        {
            counterTimer += Time.deltaTime;
            if (counterTimer >= counterTime)
            {
                countering = false;
                counterTimer = 0;
                animManager.StopCounter();
                CanCounter(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && !countering && !throwingScript.IsThrown())
        {
            animManager.Counter();
            countering = true;
            counterTimer = 0;
        }
    }

    public void CanCounter(bool canCounter)
    {
        this.canCounter = canCounter;
    }

    public bool CanCounter()
    {
        return canCounter;
    }

    public bool isCountering()
    {
        return countering;
    }
}
