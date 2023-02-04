using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerTest : MonoBehaviour
{
    public float contador = 0;
    public TextMeshProUGUI textoPrueba;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contar();
        mostrar();
    }

    public void contar()
    {
        contador += 1 * Time.deltaTime;
    }

    public void mostrar()
    {
        textoPrueba.text = Mathf.Floor(contador/60).ToString("00") + ":" + Mathf.Floor(contador%60).ToString("00");
    }
}
