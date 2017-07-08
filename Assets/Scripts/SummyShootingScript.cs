using UnityEngine;
using System.Collections;

public class SummyShootingScript : MonoBehaviour {


    private float timer = 0f;
    public float timerLimiter = 1;
    public GameObject bullet;
    public Transform spawn;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
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
