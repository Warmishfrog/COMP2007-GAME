using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win_door : MonoBehaviour
{
    private Animator _door1Anim;
    private Animator _door2Anim;

    private bool wonce;
    // Start is called before the first frame update
    void Start()
    {
        wonce = false;
        _door1Anim = gameObject.GetComponent<Animator>();
        _door2Anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CoinPickup.coinsCollected >= 5 && wonce == false)
        {
            wonce = true;
            _door1Anim.SetTrigger("doorTrigger");
            _door2Anim.SetTrigger("doorTrigger");
        }
    }
}
