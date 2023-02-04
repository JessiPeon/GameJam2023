using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ResultadoNota : MonoBehaviour
{
    public int vida = 250;
    public int vidaMax = 1000;
    public int puntajeMostrado = 0;
    public int puntajeNuevo = 0;

    public TextMeshProUGUI puntajeUI;
    public Slider slider;
    public GameObject prefabParticles;

    [SerializeField] private GameObject circle1;
    [SerializeField] private GameObject circle2;
    [SerializeField] private GameObject circle3;
    [SerializeField] private GameObject circle4;
    private ParticleSystem huesitos1;
    private ParticleSystem huesitos2;
    private ParticleSystem huesitos3;
    private ParticleSystem huesitos4;

    private void Start()
    {
        puntajeMostrado = puntajeNuevo;
        Vector3 positionCircle1 = Camera.main.transform.InverseTransformPoint(circle1.transform.position);
        huesitos1 = GameObject.Instantiate(prefabParticles, positionCircle1, Quaternion.identity).GetComponent<ParticleSystem>();

        Vector3 positionCircle2 = Camera.main.transform.InverseTransformPoint(circle2.transform.position);
        huesitos2 = GameObject.Instantiate(prefabParticles, positionCircle2, Quaternion.identity).GetComponent<ParticleSystem>();

        Vector3 positionCircle3 = Camera.main.transform.InverseTransformPoint(circle3.transform.position);
        huesitos3 = GameObject.Instantiate(prefabParticles, positionCircle3, Quaternion.identity).GetComponent<ParticleSystem>();

        Vector3 positionCircle4 = Camera.main.transform.InverseTransformPoint(circle4.transform.position);
        huesitos4 = GameObject.Instantiate(prefabParticles, positionCircle4, Quaternion.identity).GetComponent<ParticleSystem>();
    }
    public void Update()
    {
        if (puntajeMostrado < puntajeNuevo)
        {
            puntajeMostrado += 5;
            puntajeUI.text = puntajeMostrado.ToString();
        }

        if (puntajeMostrado > puntajeNuevo)
        {
            puntajeMostrado -= 5;
            puntajeUI.text = puntajeMostrado.ToString();
        }
    }

    private void disparaHuesitos(int numCircle)
    {
        if (numCircle == 1)
        {
            huesitos1.Play();
        }
        if (numCircle == 2)
        {
            huesitos2.Play();
        }
        if (numCircle == 3)
        {
            huesitos3.Play();
        }
        if (numCircle == 4)
        {
            huesitos4.Play();
        }
    }

    public void SacaPerfect(int numCircle)
    {
        vida += 200;
        if(vida > 1000)
        {
            vida = 1000;
        }
        slider.value = vida;
        puntajeNuevo += 200;
        disparaHuesitos(numCircle);
    }

    public void SacaGood(int numCircle)
    {
        vida += 100;
        if (vida > 1000)
        {
            vida = 1000;
        }
        slider.value = vida;
        puntajeNuevo += 100;
    }

    public void SacaOK(int numCircle)
    {
        vida += 50;
        if (vida > 1000)
        {
            vida = 1000;
        }
        slider.value = vida;
        puntajeNuevo += 50;
    }

    public void SacaBad(int numCircle)
    {
        vida -= 50;
        if (vida < 0)
        {
            vida = 0;
        }
        slider.value = vida;
        puntajeNuevo -= 50;
    }

    public void SacaMiss(int numCircle)
    {
        vida -= 100;
        if (vida < 0)
        {
            vida = 0;
        }
        slider.value = vida;
        puntajeNuevo -= 100;
    }
}
