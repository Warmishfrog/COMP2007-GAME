using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win_rose : MonoBehaviour
{
    public bool alive;
    private GameObject _rose;

    // Start is called before the first frame update
    void Start()
    {
        alive = false;
        _rose.SetActive(alive);
    }

    // Update is called once per frame
    public void Update()
    {

        _rose.SetActive(alive);
        if (CoinPickup.coinsCollected >= 5 && alive ==false)
        {
            UnityEngine.Debug.Log("You currently have enough coiins!!!");
            print("ALIVE!");
            alive = true;
        }
    }
}
