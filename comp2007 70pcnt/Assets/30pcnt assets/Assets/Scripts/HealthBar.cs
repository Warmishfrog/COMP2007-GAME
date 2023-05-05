using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthBar : MonoBehaviour
{
    //Creates the variables to manipulate the gameobjects in the UI
    public Slider slider_hp;
    public TextMeshProUGUI value_hp;

    // Start is called before the first frame update
    void Start()
    {
        slider_setup();
    }

    //When the script is started the values are initiated and will start at these values
    public void slider_setup() 
    {
        slider_hp.value = 5; //sets current value
        slider_hp.maxValue = 20; //sets the hard limit for the health
    }
    public void TakeDamage()
    {
        print("Health Decreased");
        slider_hp.value -= 1; //reduces health by 1
    }
    public void AddHealth()
    {
        print("Health Increased");
        slider_hp.value += 1; //increases health by 1
    }


    // Update is called once every frame //the systems internal clock
    void Update()
    {
        value_hp.text = slider_hp.value.ToString(); //displays the current Health on the UI bar 

        if (slider_hp.value < slider_hp.maxValue / 4) //when the health gets low the UI will display a warning exclamation mark to signify low health
        {
            value_hp.text = value_hp.text + "!";
        }

        if (Input.GetKeyDown(KeyCode.Equals)) //uses the plus key on the keyboard to increase health
        {
            AddHealth();
        }
        if (Input.GetKeyDown(KeyCode.Minus)) //uses the minus key on the keyboard to decrease health
        {
            TakeDamage();
        }
    }
}
