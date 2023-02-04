using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Controls : MonoBehaviour
{
    [SerializeField] private Image circle1;
    [SerializeField] private Image circle2;
    [SerializeField] private Image circle3;
    [SerializeField] private Image circle4;

    public static event Action<int> saveTime;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z))
        if (Input.GetButton("Circle1"))
        {
            circle1.color = Color.red;
            //saveTime?.Invoke(1);
        }
        if (Input.GetButton("Circle2"))
        {
            circle2.color = Color.blue;
            //saveTime?.Invoke(2);
        }
        if (Input.GetButton("Circle3"))
        {
            circle3.color = Color.green;
            //saveTime?.Invoke(3);
        }
        if (Input.GetButton("Circle4"))
        {
            circle4.color = Color.yellow;
            //saveTime?.Invoke(4);
        }
        if (Input.GetButtonUp("Circle1"))
        {
            circle1.color = Color.white;
        }
        if (Input.GetButtonUp("Circle2"))
        {
            circle2.color = Color.white;
        }
        if (Input.GetButtonUp("Circle3"))
        {
            circle3.color = Color.white;
        }
        if (Input.GetButtonUp("Circle4"))
        {
            circle4.color = Color.white;
        }
    }
    public void IluminaCirculo(int circle)
    {
        if (circle == 1)
        {
            circle1.color = Color.red;
        }
        if (circle == 2)
        {
            circle2.color = Color.blue;
        }
        if (circle == 3)
        {
            circle3.color = Color.green;
        }
        if (circle == 4)
        {
            circle4.color = Color.yellow;
        }
        StartCoroutine(restartColor(circle));
    }

    IEnumerator restartColor(int circle)
    {
        yield return new WaitForSeconds(.1f);
        if (circle == 1)
        {
            circle1.color = Color.white;
        }
        if (circle == 2)
        {
            circle2.color = Color.white;
        }
        if (circle == 3)
        {
            circle3.color = Color.white;
        }
        if (circle == 4)
        {
            circle4.color = Color.white;
        }
    }
}
