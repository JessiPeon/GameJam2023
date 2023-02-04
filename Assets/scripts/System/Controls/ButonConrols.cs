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

    [Space(30f)]
    public string axisCircle1 = "Circle1";
    public string axisCircle2 = "Circle2";
    public string axisCircle3 = "Circle3";
    public string axisCircle4 = "Circle4";

    [Space(30f)]

    public float lastImputCircle1 = 0;
    public float lastImputCircle2 = 0;
    public float lastImputCircle3 = 0;
    public float lastImputCircle4 = 0;

    [Space(30f)]

    public float ImputTimerDuration = .2f;

    [Space(30f)]

    public float _ImputTimer1 = 0;
    public float _ImputTimer2 = 0;
    public float _ImputTimer3 = 0;
    public float _ImputTimer4 = 0;

    void FixedUpdate()
    {

        if(_ImputTimer1 > 0)
        {
            _ImputTimer1 -= 1 * Time.fixedDeltaTime;
        }
        else
        {
            _ImputTimer1 = 0;
            circle1.color = Color.white;
        }
        if ( Input.GetAxis(axisCircle1) > 0 && lastImputCircle1 < 1)
        {
            _ImputTimer1 = ImputTimerDuration;
            lastImputCircle1 = 1;
            Sistema.data.renderSong.CheckButtonPress(0, Mathf.CeilToInt(Sistema.data.musicTimer.Samples));
            circle1.color = Color.yellow;

        }
        if (Input.GetAxis(axisCircle1) == 0 && lastImputCircle1 > 0)
        {
            lastImputCircle1 = 0;
            //circle1.color = Color.white;
        }

        if (_ImputTimer2 > 0)
        {
            _ImputTimer2 -= 1 * Time.fixedDeltaTime;
        }
        else
        {
            _ImputTimer2 = 0;
            circle2.color = Color.white;
        }
        if (Input.GetAxis(axisCircle2) > 0 && lastImputCircle2 < 1)
        {
            _ImputTimer2 = ImputTimerDuration;
            lastImputCircle2 = 1;
            Sistema.data.renderSong.CheckButtonPress(1, Mathf.CeilToInt(Sistema.data.musicTimer.Samples));
            circle2.color = Color.blue;

        }
        if (Input.GetAxis(axisCircle2) == 0 && lastImputCircle2 > 0)
        {
            lastImputCircle2 = 0;
            //circle2.color = Color.white;

        }

        if (_ImputTimer3 > 0)
        {
            _ImputTimer3 -= 1 * Time.fixedDeltaTime;
        }
        else
        {
            _ImputTimer3 = 0;
            circle3.color = Color.white;
        }
        if (Input.GetAxis(axisCircle3) > 0 && lastImputCircle3 < 1)
        {
            _ImputTimer3 = ImputTimerDuration;
            lastImputCircle3 = 1;
            Sistema.data.renderSong.CheckButtonPress(2, Mathf.CeilToInt(Sistema.data.musicTimer.Samples));
            circle3.color = Color.red;

        }
        if (Input.GetAxis(axisCircle3) == 0 && lastImputCircle3 > 0)
        {
            lastImputCircle3 = 0;
            //circle3.color = Color.white;

        }

        if (_ImputTimer4 > 0)
        {
            _ImputTimer4 -= 1 * Time.fixedDeltaTime;
        }
        else
        {
            _ImputTimer4 = 0;
            circle4.color = Color.white;
        }
        if (Input.GetAxis(axisCircle4) > 0 && lastImputCircle4 < 1)
        {
            _ImputTimer4 = ImputTimerDuration;
            lastImputCircle4 = 1;
            Sistema.data.renderSong.CheckButtonPress(3, Mathf.CeilToInt(Sistema.data.musicTimer.Samples));
            circle4.color = Color.green;

        }

        if (Input.GetAxis(axisCircle4) == 0 && lastImputCircle4 > 0)
        {
            lastImputCircle4 = 0;
            //circle4.color = Color.white;

        }

        //    if (Input.GetButton("Circle1"))
        //    {
        //        Sistema.data.renderSong.CheckButtonPress(0,Mathf.CeilToInt(Sistema.data.musicTimer.Samples));
        //        circle1.color = Color.yellow;
        //    }
        //    if (Input.GetButtonUp("Circle1"))
        //    {
        //        circle1.color = Color.white;
        //    }


        //    if (Input.GetButton("Circle2"))
        //    {
        //        Sistema.data.renderSong.CheckButtonPress(1, Mathf.CeilToInt(Sistema.data.musicTimer.Samples));

        //        circle2.color = Color.blue;
        //    }
        //    if (Input.GetButtonUp("Circle2"))
        //    {
        //        circle2.color = Color.white;
        //    }


        //    if (Input.GetButton("Circle3"))
        //    {
        //        Sistema.data.renderSong.CheckButtonPress(2, Mathf.CeilToInt(Sistema.data.musicTimer.Samples));

        //        circle3.color = Color.red;
        //    }
        //    if (Input.GetButtonUp("Circle3"))
        //    {
        //        circle3.color = Color.white;
        //    }


        //    if (Input.GetButton("Circle4"))
        //    {
        //        Sistema.data.renderSong.CheckButtonPress(3, Mathf.CeilToInt(Sistema.data.musicTimer.Samples));

        //        circle4.color = Color.green;
        //    }
        //    if (Input.GetButtonUp("Circle4"))
        //    {
        //        circle4.color = Color.white;
        //    }
    }


}
