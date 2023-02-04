using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicTimer : MonoBehaviour
{
    public Camera camaraPrincipal;
    public float BordeDeLaPantalla;

    public float samplesToSpawnSeconds = 1f; //1 segundos
    public float samplesToSpawn = 44100f; //1 segundos

    public float Time = 0;
    public float Samples = 0;
    public TextMeshProUGUI textoPruebaTime;
    public TextMeshProUGUI textoPruebaSamples;
    public TextMeshProUGUI textoPruebaSampleRate;
    public TextMeshProUGUI textoPruebaNombre;
    [Space(20f)]
    public AudioSource audioSource;
    public AudioClip Musica;
    [Space(20f)]
    public float SapmleRate;

    [Space(20f)]
    public float UltimoTiempo = 0f;
    public float UltimoSample = 0f;
    public float DeltaTiempo = 0f;
    public float DeltaSample = 0f;

    private void Awake()
    {
        if (Sistema.data.musicTimer == null)
        {
            Sistema.data.musicTimer = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(samplesToSpawnSeconds != 0)
        {
            samplesToSpawn = samplesToSpawnSeconds * 44100;
        }
        textoPruebaNombre.text = Musica.name;
        contar();
    }

    // Update is called once per frame
    void Update()
    {
        contar();
        mostrar();
    }

    public void contar()
    {
        //rellenando ultimo valor del contador
        UltimoTiempo = Time;
        UltimoSample = Samples;

        //calculando el tiempo y el tiempo en samples 
        Time = audioSource.time;
        Samples = audioSource.timeSamples;

        //calculando deltas
        DeltaTiempo = Time - UltimoTiempo;
        DeltaSample = Samples - UltimoSample;

        //calculando sample rate para debug
        SapmleRate = Samples / Time;

    }

    public void mostrar()
    {
        //textoPruebaTime.text = Mathf.Floor(Time / 60).ToString("00") + ":" + Mathf.Floor(Time % 60).ToString("00");
        //textoPruebaSamples.text = Mathf.Floor(Time).ToString();
        //textoPruebaSampleRate.text = $"delta sample: {DeltaSample}. delta tiempo: {DeltaTiempo}";
    }

    public void CalcularDeltaTiempo()
    {
        DeltaTiempo = Time - UltimoTiempo;
        DeltaSample = Samples - UltimoSample;
    }



}
