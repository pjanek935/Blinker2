using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeSlowMotion : MonoBehaviour
{

    private SlowMotion slowMotion;

    // Use this for initialization
    void Start()
    {
        slowMotion = GameObject.FindGameObjectWithTag("Player").GetComponent<SlowMotion>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" && slowMotion.CanSlowMotion())
        {
            slowMotion.startSlowMotion();
        }
    }
}
