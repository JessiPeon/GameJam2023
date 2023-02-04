using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButonConrols : MonoBehaviour
{ 
    [SerializeField] private Image circle1;
    [SerializeField] private Image circle2;
    [SerializeField] private Image circle3;
    [SerializeField] private Image circle4;

    public static event Action<int> saveTime;

    void Update()
    {
        
        if (Input.GetButton("Circle1"))
        {
            circle1.color = Color.yellow;
        }
        if (Input.GetButtonUp("Circle1"))
        {
            circle1.color = Color.white;
        }


        if (Input.GetButton("Circle2"))
        {
            circle2.color = Color.blue;
        }
        if (Input.GetButtonUp("Circle2"))
        {
            circle2.color = Color.white;
        }


        if (Input.GetButton("Circle3"))
        {
            circle3.color = Color.red;
        }
        if (Input.GetButtonUp("Circle3"))
        {
            circle3.color = Color.white;
        }


        if (Input.GetButton("Circle4"))
        {
            circle4.color = Color.green;
        }
        if (Input.GetButtonUp("Circle4"))
        {
            circle4.color = Color.white;
        }
    }
}
