using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicTimer : MonoBehaviour
{
    public float contador = 0;
    public float contadorSamples = 0;
    public TextMeshProUGUI textoPruebaTime;
    public TextMeshProUGUI textoPruebaSamples;
    public TextMeshProUGUI textoPruebaSampleRate;
    public TextMeshProUGUI textoPruebaNombre;

    public AudioSource audioSource;
    public AudioClip Musica;

    public float sapmleRate;

    // Start is called before the first frame update
    void Start()
    {
        textoPruebaNombre.text = Musica.name;
    }

    // Update is called once per frame
    void Update()
    {
        contar();
        mostrar();
    }

    public void contar()
    {
        contador = audioSource.time;
        contadorSamples = audioSource.timeSamples;
        sapmleRate = contadorSamples / contador; //Musica.length;

    }

    public void mostrar()
    {
        textoPruebaTime.text = Mathf.Floor(contador / 60).ToString("00") + ":" + Mathf.Floor(contador % 60).ToString("00");
        textoPruebaSamples.text = Mathf.Floor(contador).ToString();
        textoPruebaSampleRate.text = (sapmleRate).ToString();
    }

}
