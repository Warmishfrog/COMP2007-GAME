using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_watching : MonoBehaviour
{
    public GameObject npcHead;
    public GameObject playerObj;

    private Vector3 delta;
    private Vector3 playerPosition;
    private Vector3 npcRotation;

    // Update is called once per frame
    void Update()
    {
        playerPosition = playerObj.transform.position;
        npcRotation = npcHead.transform.position;
        delta = new Vector3(playerPosition.x - npcRotation.x, 0.0f, playerPosition.z - npcRotation.z);
        Quaternion rotation = Quaternion.LookRotation(delta);
        npcHead.transform.rotation = rotation;
    }
}
