using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNPCAlpha : MonoBehaviour {

    public Transform player;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float playerD = Vector3.Distance(player.position, transform.position);

        if (playerD < 10)
        {
            float alpha = 0;
            Renderer renderer = GetComponent<Renderer>();
            Color color = renderer.material.color;
            color.a = alpha;
            renderer.material.color = color;
        }
        else if (playerD < 30)
        {
            float alpha = (playerD-10) / 20;
            Renderer renderer = GetComponent<Renderer>();
            Color color = renderer.material.color;
            color.a = alpha;
            renderer.material.color = color;
        }
    }
}
