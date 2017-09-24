using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScipt : MonoBehaviour {

    public Transform bulletSpawnLeft, buleltSpawnRigh;
    public GameObject projectile;
    public Transform player;
    public float rotationSpeed = 1f;
    public float movementSpeed = 1f;

    private Vector3 offsetVector;

    private static System.Random rand = new System.Random ();

	// Use this for initialization
	void Start () {
        float minD = 10;
        float r = 10;
        offsetVector = new Vector3 ((float) (minD + r * rand.NextDouble()),
                                    (float)(minD + r * rand.NextDouble()),
                                    (float)(minD + r * rand.NextDouble()));
	}
	
	// Update is called once per frame
	void Update () {
        Turn();
        Follow();
	}

    void OnEnable()
    {
        StartShootingCycle();
    }

    void Turn()
    {
        Vector3 direction = player.position - transform.position;
        Vector3 directionDiff = direction - transform.forward;
        directionDiff /= 500f;
        directionDiff *= rotationSpeed;
        transform.forward += directionDiff;
    }

    void Follow()
    {
        Vector3 target = player.transform.position + offsetVector;
        Vector3 movementDirection = target - transform.position;
        movementDirection /= 500f;
        movementDirection *= movementSpeed;
        transform.position += movementDirection;
    }

    void StartShootingCycle()
    {
        if (isActiveAndEnabled)
            StartCoroutine(Shoot());
    }

    IEnumerator Shoot ()
    {
        GameObject bullet = Instantiate (projectile, bulletSpawnLeft);
        Vector3 bulletDirection = player.position - bulletSpawnLeft.position;
        //bullet.transform.forward = bulletDirection;
        bullet.transform.position = bulletSpawnLeft.position;


        yield return new WaitForSeconds(1f);
        StartShootingCycle();
    }
}
