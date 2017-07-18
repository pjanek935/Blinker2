using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shooting script for training dummy
public class DummyShootingScript : MonoBehaviour {

    private float timer = 0f;
    public float timerLimiter = 1;
    public GameObject bullet;
    public Transform spawn;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerLimiter)
        {
            timer = 0;
            shoot();
        }
    }

    public void shoot()
    {
        Instantiate(bullet, spawn.position, spawn.rotation);
    }
}
