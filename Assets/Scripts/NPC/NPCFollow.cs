using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollow : MonoBehaviour
{
    //Target Object
    public Transform player;

    //Check if NPC is walking
    public bool isLooking = true;

    // Update is called once per frame
    void Update()
    {
        if (isLooking)
        {
            Vector3 playerPos = player.position;
            Vector3 npcPos = this.transform.position;
            Vector3 delta = new Vector3(playerPos.x - npcPos.x, 0.0f, playerPos.z - npcPos.z);

            Quaternion rotation = Quaternion.LookRotation(delta);
            this.transform.rotation = rotation;
        }
    }

   void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "NPCPoint")
        {
            isLooking = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "NPCPoint")
        {
            isLooking = false;
        }
    }
}
