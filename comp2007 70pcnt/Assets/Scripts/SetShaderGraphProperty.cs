using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShaderGraphProperty : MonoBehaviour
{
    public Color MyNewColour;
    
    void Start()
    {
        GetComponent<Renderer>().material.SetColor("_My_Colour", MyNewColour);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
