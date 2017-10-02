using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScipt : MonoBehaviour {

    public Transform bulletSpawnLeft, bulletSpawnRight;
    public GameObject projectile;
    public Transform player;
    public float rotationSpeed = 1f;
    public float movementSpeed = 1f;

    private Vector3 offsetVector;
    private bool active = true;
    private AIMODE mode = AIMODE.SHOOT;
    private bool shootSide = false;
    private Vector3 lastPlayerPosition;
    private bool canSeePlayer = true;

    private static System.Random rand = new System.Random();

    public enum AIMODE { SHOOT, MELEE}

    public bool Active
    {
        get { return active; }
        set { active = value; }
    }

	// Use this for initialization
	void Start () {
        float minD = 10;
        float r = 10;
        offsetVector = new Vector3 ((float) (minD + r * rand.NextDouble()),
                                    (float)(minD + r * rand.NextDouble()),
                                    (float)(minD + r * rand.NextDouble()));
        lastPlayerPosition = player.position;
	}

    public void ChangeMode (AIMODE mode)
    {
        this.mode = mode;
    }
	
	// Update is called once per frame
	void Update () {

        if (active)
        {
            findLastPlayerPosition();
            Turn();
            Follow();            
        }
	}

    void OnEnable()
    {
        StartShootingCycle();
    }

    void findLastPlayerPosition ()
    {
        Vector3 raycastDirection = player.position - transform.position;
        RaycastHit hit;

        if (Physics.Raycast(transform.position + transform.forward * 5, raycastDirection, out hit))
        {
            if (string.Equals (hit.collider.tag, "Player") || string.Equals (hit.collider.tag, "PlayerFace"))
            {
                Debug.DrawRay(transform.position + transform.forward * 5, raycastDirection, Color.red, 0.05f);
                lastPlayerPosition = player.position;
                canSeePlayer = true;
            }
            else
            {
                canSeePlayer = false;
            }
        }  
    }

    void Turn()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        Vector3 directionDiff = direction - transform.forward;

        if (mode == AIMODE.MELEE)
        {
            directionDiff *= (rotationSpeed * 2f);
        }
        else
        {
            directionDiff *= rotationSpeed;
        }
        
        transform.forward += directionDiff;
    }

    void Follow()
    {
        Vector3 target = lastPlayerPosition;

        if (mode == AIMODE.SHOOT)
        {
            target += offsetVector;
        }
  
        Vector3 movementDirection = target - transform.position;
        movementDirection.Normalize();

        if (mode == AIMODE.MELEE)
        {
            movementDirection *= (movementSpeed * 2f);
        }
        else
        {
            movementDirection *= movementSpeed;
        }
        
        transform.position += movementDirection;
    }

    void StartShootingCycle()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot ()
    {
        if (active && mode == AIMODE.SHOOT && canSeePlayer)
        {
            GameObject bullet = Instantiate(projectile, bulletSpawnLeft);

            Vector3 spawnPosition = bulletSpawnLeft.position;

            if (shootSide)
            {
                spawnPosition = bulletSpawnRight.position;
            }

            shootSide = !shootSide;
            Vector3 bulletDirection = lastPlayerPosition - spawnPosition;

            if (shootSide)
            {
                bullet.transform.position = bulletSpawnRight.position;
            }
            else
            {
                bullet.transform.position = bulletSpawnLeft.position;
            }
        }
        
        yield return new WaitForSeconds(1f);

        StartShootingCycle();
    }
}
