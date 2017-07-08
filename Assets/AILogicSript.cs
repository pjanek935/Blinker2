using UnityEngine;
using System.Collections;

public class AILogicSript : MonoBehaviour {

    public Transform goal;
    public GameObject undestroyableProjectile;
    public GameObject destroyableProjectile;

    private float timerLimiter = 0.5f;
    private float timer = 0;
    private bool projectileType = true;

	// Use this for initialization
	void Start () {
        //NavMeshAgent agent = GetComponent<NavMeshAgent>();
        //agent.destination = goal.position;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= timerLimiter)
        {
            Shoot();
            timer = 0;
        }
	}

    void FixedUpdate()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
    }

    void Shoot()
    {

        Quaternion rot = transform.rotation;
        rot *= Quaternion.Euler(Vector3.right * -90);
        if (projectileType)
        {
            Instantiate(destroyableProjectile, transform.position + transform.forward * 6.0f, rot);
        }else
        {
            Instantiate(undestroyableProjectile, transform.position + transform.forward * 6.0f, rot);
        }

        projectileType = !projectileType;
        
    }
}
