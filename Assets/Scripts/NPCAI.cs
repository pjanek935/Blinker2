using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour {

    public Transform player;

    private List<Transform> poi;
    private int currentPOI = 0;
    private NavMeshAgent agent;
    private Animator animator;

    private bool idle = false;
    private float timer = 0;
    private float idleLimiter = 3;
    private static System.Random random = new System.Random();

    // Use this for initialization
    void Start () {
        GameObject poiContener = GameObject.Find("POI");
        int childCount = poiContener.transform.childCount;
        poi = new List<Transform>();
        for (int i=0; i<childCount; i++)
        {
            poi.Add(poiContener.transform.GetChild(i));
        }

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        currentPOI = random.Next(0, poi.Count);
        agent.speed = 5;
        animator.SetTrigger("walk");
    }

    // Update is called once per frame
    void Update () {

        if (idle)
        {
            timer += Time.deltaTime;
            if (timer >= idleLimiter)
            {
                timer = 0;
                idle = false;
                if (random.NextDouble() > 0.5)
                {
                    animator.SetTrigger("walk");
                    agent.speed = 5;
                }
                else
                {
                    animator.SetTrigger("run");
                    agent.speed = 10;
                }
                
                return;
            }
        }
        else
        {
            agent.destination = poi[currentPOI].position;
            float d = Vector3.Distance(poi[currentPOI].position, transform.position);
            if (d < 5)
            {
                currentPOI = random.Next(0, poi.Count);
                if (currentPOI >= poi.Count)
                {
                    currentPOI = 0;
                }
                idle = true;
                idleLimiter = (float)(random.NextDouble() * 5 + 3);
                int rand = random.Next(1, 5);
                animator.SetTrigger("idle" + rand);
            }
        }

        

        

        //agent.destination = player.position;

        //float d = Vector3.Distance(player.position, transform.position);
        //if (d > 20)
        //{
        //    agent.speed = 20;
        //    animator.SetBool("Run", true);
        //    animator.SetBool("Walk", false);
        //}
        //else
        //{
        //    agent.speed = 10;
        //    animator.SetBool("Walk", true);
        //    animator.SetBool("Run", false);
        //}

        //if (d< 10)
        //{
        //    agent.speed = 0;
        //    animator.SetTrigger("Punch");
        //}
    }
}
