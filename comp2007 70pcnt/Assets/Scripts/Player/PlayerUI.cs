using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public GameObject pauseMenu = null;
    public GameObject Button_resume = null;

    public TextMeshProUGUI CoinCounter;
    public int cc;
    public bool isPaused;
    public bool isResume;

    // Start is called before the first frame update
    void Start()
    {
        CoinPickup.coinsCollected = 0;
        CoinPickup.coinsCollected += cc;

        isPaused = false;
        pauseMenu.SetActive(isPaused);
        Button_resume.SetActive(isPaused);

    }

    // Update is called once per frame
    void Update()
    {
        CoinCounter.text = CoinPickup.coinsCollected + " / 5";


        if (Input.GetKeyDown(KeyCode.Escape) && CoinPickup.coinsCollected < 6 && CoinPickup.coinsCollected >=0)
        {            
            isResume = true;
            PauseFunction();            
        }
        if (CoinPickup.coinsCollected == 6)
            CoinCounter.text = "Collect your flower";
        if (CoinPickup.coinsCollected >= 7)
        {
            isResume = false;
            CoinCounter.text = "You Won!";
            MENUSCREEN.hasWon = true;
            PauseFunction();
        }
        if (CoinPickup.coinsCollected < 0)
        {
            isResume = false;
            CoinCounter.text = "You DIED!";
            PauseFunction();
        }        
    }

    public void PauseFunction()
    {

        if (isResume == false)
        {
            isPaused = true;
            Button_resume.SetActive(false);
        }
        else
        {
            Button_resume.SetActive(true);
            isPaused = !isPaused;
        }

        Time.timeScale = isPaused ? 0 : 1;
        pauseMenu.SetActive(isPaused);
        Cursor.visible = isPaused;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        //print(isPaused);
    }

}
