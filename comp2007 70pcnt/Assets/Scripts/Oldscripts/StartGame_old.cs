using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Diagnostics;

public class StartGame : MonoBehaviour
{
   public void startgame()
    {

        SceneManager.LoadScene(1);
        print("Game Started");
    }
    public void exit()
    {
        Application.Quit();
        print("exited");
    }
}
