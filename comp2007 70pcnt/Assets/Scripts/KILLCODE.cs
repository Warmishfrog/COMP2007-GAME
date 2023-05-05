using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class KILLCODE : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves a specific tag
        if (collision.gameObject.CompareTag("Player"))
        {
            CoinPickup.coinsCollected = -1;
            print("player DIED");
        }
    }
}
