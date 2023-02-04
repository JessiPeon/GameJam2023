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

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            circle1.color = Color.white;
            saveTime?.Invoke(1);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            circle1.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            circle2.color = Color.white;
            saveTime?.Invoke(2);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            circle2.color = Color.blue;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            circle3.color = Color.white;
            saveTime?.Invoke(3);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            circle3.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            circle4.color = Color.white;
            saveTime?.Invoke(4);
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            circle4.color = Color.yellow;
        }
    }
}
