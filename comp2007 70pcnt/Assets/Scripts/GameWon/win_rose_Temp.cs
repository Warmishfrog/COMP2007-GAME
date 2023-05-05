using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win_rose_Temp : MonoBehaviour
{
    public bool alive;
    private SphereCollider roseCol;
    public GameObject RosePhysical;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        roseCol = gameObject.GetComponent<SphereCollider>();
        roseCol.enabled = false;
        RosePhysical.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        if (CoinPickup.coinsCollected >= 6)
        {
            roseCol.enabled = true;
            roseCol.isTrigger = true;
            RosePhysical.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider roseCol)
    {
        if (roseCol.CompareTag("Player"))
        {
            print("YOU GOT THE FLOWERS");
            CoinPickup.coinsCollected++;
        }
    }
}
