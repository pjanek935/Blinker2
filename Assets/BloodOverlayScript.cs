﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodOverlayScript : MonoBehaviour {

    private enum State { NONE, FADE_IN, FADE_OUT}

    private State state = State.NONE;

	// Use this for initialization
	void Start () {
        Color color = GetComponent<Image>().color;
        color.a = 0;
        GetComponent<Image>().color = color;
	}
	
	// Update is called once per frame
	void Update () {
        if (state == State.FADE_OUT)
        {
            Color color = GetComponent<Image>().color;
            color.a -= 0.001f;
            GetComponent<Image>().color = color;
        }
	}

    public void Blink()
    {
        state = State.FADE_IN;
        Color color = GetComponent<Image>().color;
        color.a = 1;
        GetComponent<Image>().color = color;
        state = State.FADE_OUT;
    }


    
}
