using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winScript : MonoBehaviour
{
    public GameObject _door1;
    public GameObject _door2;
    public GameObject _roseObj;
    public SphereCollider roseCol;

    private Animator _door1Anim;
    private Animator _door2Anim;

    public bool alive;

    // Start is called before the first frame update
    void Start()
    {
        alive = false;
        _door1Anim = _door1.GetComponent<Animator>();
        _door2Anim = _door2.GetComponent<Animator>();
        roseCol = roseCol.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    public void Update()
    {
        _roseObj.SetActive(alive);
        if (CoinPickup.coinsCollected >= 5 && alive== false)
        {               
                GameWon();
        }
        
    }

    public void GameWon()
    {
        alive = true;
        roseCol.enabled = true;
        roseCol.isTrigger = true;
        _door1Anim.SetTrigger("doorTrigger");
        _door2Anim.SetTrigger("doorTrigger");
        
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

    void OnCollisionEnter(Collision roseCol)
    {
        print("i'm gonna kms");
    }
}
