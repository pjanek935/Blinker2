using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Changes NPC's alpha when close to player
public class ChangeNPCAlpha : MonoBehaviour {

    public Transform player;
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(player.position, transform.position);
        float alpha = 0;
        if (distance < 30 && distance > 10)
            alpha = (distance - 10) / 20;
        Renderer renderer = GetComponent<Renderer>();
        Color color = renderer.material.color;
        color.a = alpha;
        renderer.material.color = color;
    }
}
