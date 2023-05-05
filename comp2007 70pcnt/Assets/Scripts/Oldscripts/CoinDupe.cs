using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDupe : MonoBehaviour
{
    public GameObject schmeckule;

    [SerializeField]
    public int bagbool;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (bagbool > 0)
        {
            GameObject go = GameObject.Instantiate(schmeckule);
            go.transform.position = schmeckule.transform.position;
            bagbool -= 1;
        }
    }
}
