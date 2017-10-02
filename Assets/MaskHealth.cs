using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskHealth : HealthScript {

    public EnemyScipt enemyScipt;
    public GameObject eyeLeft;
    public GameObject eyeRight;

    // Use this for initialization
    void Start () {
        Init();
	}

    public override void Death()
    {
        gameObject.transform.parent = null;
        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        enemyScipt.ChangeMode(EnemyScipt.AIMODE.MELEE);

        Destroy(eyeLeft);
        Destroy(eyeRight);
    }
}
