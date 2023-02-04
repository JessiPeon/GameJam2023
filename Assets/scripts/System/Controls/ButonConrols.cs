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

    //public static event Action<int> saveTime;
    //[Space(20f)]

    public string axisCircle1 = "Circle1";
    public string axisCircle2 = "Circle2";
    public string axisCircle3 = "Circle3";
    public string axisCircle4 = "Circle4";
    //[Space(20f)]
    public bool butonCircle1Pressed = false;
    public bool butonCircle2Pressed = false;
    public bool butonCircle3Pressed = false;
    public bool butonCircle4Pressed = false;

    public bool butonCircle1PressedEnd = false;
    public bool butonCircle2PressedEnd = false;
    public bool butonCircle3PressedEnd = false;
    public bool butonCircle4PressedEnd = false;

    void Update()
    {

        if (Input.GetAxis(axisCircle1) > 0)
        {

            if (!butonCircle1Pressed)
            {
                butonCircle1Pressed = true;
                if (!butonCircle1PressedEnd)
                {
                    butonCircle1PressedEnd = true;
                    butonCircle1Pressed = false;
                }
            }
        }
        else
        {
            if (butonCircle1Pressed)
            {
                butonCircle1Pressed = false;
                butonCircle1PressedEnd = false;
            }
        }

        if (Input.GetButton("Circle1"))
        {
            Sistema.data.renderSong.CheckButtonPress(0,Mathf.CeilToInt(Sistema.data.musicTimer.Samples));
            circle1.color = Color.yellow;
        }
        if (Input.GetButtonUp("Circle1"))
        {
            circle1.color = Color.white;
        }


        if (Input.GetButton("Circle2"))
        {
            Sistema.data.renderSong.CheckButtonPress(1, Mathf.CeilToInt(Sistema.data.musicTimer.Samples));

            circle2.color = Color.blue;
        }
        if (Input.GetButtonUp("Circle2"))
        {
            circle2.color = Color.white;
        }


        if (Input.GetButton("Circle3"))
        {
            Sistema.data.renderSong.CheckButtonPress(2, Mathf.CeilToInt(Sistema.data.musicTimer.Samples));

            circle3.color = Color.red;
        }
        if (Input.GetButtonUp("Circle3"))
        {
            circle3.color = Color.white;
        }


        if (Input.GetButton("Circle4"))
        {
            Sistema.data.renderSong.CheckButtonPress(3, Mathf.CeilToInt(Sistema.data.musicTimer.Samples));

            circle4.color = Color.green;
        }
        if (Input.GetButtonUp("Circle4"))
        {
            circle4.color = Color.white;
        }
    }


}
