using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButons : MonoBehaviour
{
    public string axisY;
    public float axisYnum;
    [Space]
    public string axisX; 
    public float axisXnum;
    [Space] 
    public string axisB; 
    public float axisBnum;
    [Space]
    public string axisA;
    public float axisAnum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        axisXnum = Input.GetAxis(axisX) > 0 ? 1 : 0;
        axisYnum = Input.GetAxis(axisY) > 0 ? 1 : 0;
        axisBnum = Input.GetAxis(axisB) > 0 ? 1 : 0;
        axisAnum = Input.GetAxis(axisA) > 0 ? 1 : 0;

        if (Input.GetAxis(axisX) > 0)
        {
            //Debug.Log("Boton X pressed!");
        }

        if (Input.GetAxis(axisY) > 0)
        {
            //Debug.Log("Boton Y pressed!");
        }

        if (Input.GetAxis(axisB) > 0)
        {
            //Debug.Log("Boton B pressed!");
        }

        if (Input.GetAxis(axisA) > 0)
        {
            //Debug.Log("Boton A pressed!");
        }
    }
}
