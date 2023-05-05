using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_interact : MonoBehaviour
{

    public SphereCollider NPC_talkcollider;
    public TextMeshPro NPC_text;
    public TextMeshPro QuestionMark;
    public GameObject interact_E = null;
    public bool isInteracting;

    public AudioSource Speaking;
    public AudioClip bs1;
    public AudioClip bs2;


    // Start is called before the first frame update
    void Start()
    {
        NPC_text.text = "";
        interact_E.SetActive(false);
        QuestionMark.text = "?";

        isInteracting = false;

        NPC_talkcollider.enabled = true;
        NPC_talkcollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInteracting)
        {
            switch (CoinPickup.coinsCollected)
            {
                case 0:
                    NPC_text.text = "5 Shmeckles for 1 Flower";
                    QuestionMark.text = "";
                    Speaking.PlayOneShot(bs1, 0.8f);
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    NPC_text.text = "You need " + (5 - CoinPickup.coinsCollected) + " more coins";
                    QuestionMark.text = "";
                    Speaking.PlayOneShot(bs1, 0.8f);
                    break;
                case 5:
                    NPC_text.text = "You Earned it, Here you go";
                    CoinPickup.coinsCollected++;
                    QuestionMark.text = "";
                    Speaking.PlayOneShot(bs2, 0.8f);
                    break;
                case 6:
                    NPC_text.text = "Go on now. It's yours";
                    Speaking.PlayOneShot(bs2, 0.8f);
                    break;
                default:
                    // handle error case or default behavior here
                    break;
            }
        }
        if (CoinPickup.coinsCollected == 5)
            QuestionMark.text = "!";
    }

    void OnTriggerEnter(Collider promptTalk)
    {
        interact_E.SetActive(true);
        isInteracting = true;
    }
    void OnTriggerExit(Collider promptTalk)
    {
        interact_E.SetActive(false);
        isInteracting = false;
        NPC_text.text = "";
    }


}