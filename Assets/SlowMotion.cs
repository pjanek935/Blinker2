using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour {

    public float slowMoWindow = 0.1f;
    public float slowMoDuration = 1f;
    public ChromaticAberration chromaticAberration;

    private float bulletTimeTimer = 0f;
    private bool canSlowMo = false;
    private bool slowmo = false;
    private float slowmoTimer = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (canSlowMo)
        {
            bulletTimeTimer += Time.deltaTime;
            if (bulletTimeTimer >= slowMoWindow)
            {
                bulletTimeTimer = 0;
                canSlowMo = false;
            }
        }

        if (slowmo)
        {
            slowmoTimer += Time.deltaTime;
            if (slowmoTimer >= slowMoDuration)
            {
                Time.timeScale = 1;
                Time.fixedDeltaTime = 0.02F;
                slowmo = false;
                chromaticAberration.ChromaticAbberation = 1;
            }
        }
    }

    public bool IsSlowMotion()
    {
        return slowmo;
    }

    public bool CanSlowMotion()
    {
        return canSlowMo;
    }

    public void EnableSlowMotion()
    {
        canSlowMo = true;
    }

    //public void DisableSlowMotion()
    //{

    //}

    public void startSlowMotion()
    {
        if (slowmo)
            return;
        chromaticAberration.ChromaticAbberation = 5;
        slowmo = true;
        slowmoTimer = 0;
        Time.timeScale = 0.4f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
}
