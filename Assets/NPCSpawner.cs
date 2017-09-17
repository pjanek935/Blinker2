using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour {

    public GameObject npc;
    public int amount = 10;

	// Use this for initialization
	void Start () {
        GameObject poiContener = GameObject.Find("POI");
        int childCount = poiContener.transform.childCount;

        int npcCount = 0;

        while (npcCount < amount)
        {
            for (int i = 0; i < childCount; i++)
            {
                GameObject npcInstance = Instantiate(npc);
                npcInstance.transform.position = poiContener.transform.GetChild(i).transform.position;
                npcCount++;

                if (npcCount >= amount)
                    break;

            }
        }
          
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
