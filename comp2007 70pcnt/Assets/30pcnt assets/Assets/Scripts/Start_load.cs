using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Diagnostics;

public class Start_load : MonoBehaviour
{
    public GameObject PTransition;
    public GameObject Loadtxt;

    public void loadscene_Chest()
    {        
        print("Chest button clicked");
        Loadtxt.SetActive(true);
        PTransition.SetActive(true);
        print("slept");
        SceneManager.LoadScene(1);
    }
    public void loadscene_UI()
    {
        print("UI button clicked");
        Loadtxt.SetActive(true);
        PTransition.SetActive(true);
        print("slept");
        SceneManager.LoadScene(2);
    }

    public void exit()
    {
        Application.Quit();
        print("exited");
    }

}



