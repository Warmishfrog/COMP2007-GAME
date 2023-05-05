using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinPickup : MonoBehaviour
{
    public static int coinsCollected;
    public SphereCollider c_coin;
    public AudioSource audioData;
    public GameObject coinobj;
    public GameObject particleobj;

    void Awake()
    {
        c_coin = GetComponent<SphereCollider>();
        c_coin.isTrigger = true;
    }


     void OnTriggerEnter(Collider c_coin)
    {
        //UnityEngine.Debug.Log("You awoken the coin");
        if (c_coin.CompareTag("Player"))
        {   

            //audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            //Add coin to counter
            coinsCollected++;
            //Test: Print total number of coins
            UnityEngine.Debug.Log("You currently have " + CoinPickup.coinsCollected + " Coins.");


            //Destroy coin
            Destroy(gameObject);

        }
    }
}
