using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CS_PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;
    float mX;
    float mY;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        transform.rotation = Quaternion.Euler(90, 90, 0);
        orientation.rotation = Quaternion.Euler(90, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        mX = Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        mY = Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
        yRotation += mX;
        xRotation -= mY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        
    }
        
}
