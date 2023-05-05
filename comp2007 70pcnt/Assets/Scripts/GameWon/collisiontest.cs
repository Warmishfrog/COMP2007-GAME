using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisiontest : MonoBehaviour
{
    private BoxCollider roseCol;

    // Start is called before the first frame update
    void Start()
    {
        roseCol = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider roseCol)
    {
        UnityEngine.Debug.Log("YOU DID IT YIPPEEE");
        print("shit");

        if (roseCol.CompareTag("Player"))
        {
            print("anything");
        }
    }
}
