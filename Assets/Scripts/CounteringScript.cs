using UnityEngine;
using System.Collections;
using System;

public class CounteringScript : MonoBehaviour {

    public float counterTime = 0.5f;

    private AnimationManagerScript animManager;
    private ThrowingScript throwingScript;
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
                StopCountering();
        }

        if (Input.GetKeyDown(KeyCode.E) && !countering && !throwingScript.IsThrown() &&
            animManager.GetState() != AnimationManagerScript.State.THROW)
            StartCountering();
        
    }

    private void StartCountering()
    {
        animManager.Counter();
        countering = true;
        counterTimer = 0;
    }

    private void StopCountering()
    {
        countering = false;
        counterTimer = 0;
        animManager.StopCounter();
        SetCanCounter(false);
    }

    public void SetCanCounter(bool canCounter)
    {
        this.canCounter = canCounter;
    }

    public bool CanCounter()
    {
        return canCounter;
    }

    public bool IsCountering()
    {
        return countering;
    }
}
