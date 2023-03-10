using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ResultadoNota : MonoBehaviour
{
    private float vida = 500; //500
    public float vidaMax = 1000; //1000
    public int puntajeMostrado = 0;
    public int puntajeNuevo = 0;

    public TextMeshProUGUI puntajeUI;
    public GameObject loserUI;
    public Button loserUIButton;
    public Image corazon;
    public AudioSource audio;
    public GameObject WinUI;


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
        puntajeMostrado = 0;
        puntajeNuevo = puntajeMostrado;
        corazon.fillAmount = vida/vidaMax;
        /*Vector3 positionCircle1 = Camera.main.transform.InverseTransformPoint(circle1.transform.position);
        huesitos1 = GameObject.Instantiate(prefabParticles, positionCircle1, Quaternion.identity).GetComponent<ParticleSystem>();

        Vector3 positionCircle2 = Camera.main.transform.InverseTransformPoint(circle2.transform.position);
        huesitos2 = GameObject.Instantiate(prefabParticles, positionCircle2, Quaternion.identity).GetComponent<ParticleSystem>();

        Vector3 positionCircle3 = Camera.main.transform.InverseTransformPoint(circle3.transform.position);
        huesitos3 = GameObject.Instantiate(prefabParticles, positionCircle3, Quaternion.identity).GetComponent<ParticleSystem>();

        Vector3 positionCircle4 = Camera.main.transform.InverseTransformPoint(circle4.transform.position);
        huesitos4 = GameObject.Instantiate(prefabParticles, positionCircle4, Quaternion.identity).GetComponent<ParticleSystem>();*/
    }
    public void Update()
    {
        if (puntajeMostrado < puntajeNuevo)
        {
            puntajeMostrado += 25;
            puntajeUI.text = puntajeMostrado.ToString();
        }

        if (puntajeMostrado > puntajeNuevo)
        {
            puntajeMostrado -= 25;
            puntajeUI.text = puntajeMostrado.ToString();
        }
        if (vida == 0) {
            loserUI.SetActive(true);
            loserUI.GetComponent<Button>().Select();
            audio.Stop();
        }
    }

    public void SacaPerfect()
    {
        vida += 200;
        if(vida > vidaMax)
        {
            vida = vidaMax;
        }
        corazon.fillAmount = vida/ vidaMax;
        puntajeNuevo += 200;
    }

    public void SacaGood()
    {
        vida += 100;
        if (vida > vidaMax)
        {
            vida = vidaMax;
        }
        corazon.fillAmount = vida/ vidaMax;
        puntajeNuevo += 100;
    }

    public void SacaOK()
    {
        vida += 50;
        if (vida > vidaMax)
        {
            vida = vidaMax;
        }
        corazon.fillAmount = vida/ vidaMax;
        puntajeNuevo += 50;
    }

    public void SacaBad()
    {
        vida -= 150;
        if (vida < 0)
        {
            vida = 0;
        }
        corazon.fillAmount = vida/ vidaMax;
        if((puntajeNuevo-150)<=0)
        {
            puntajeNuevo = 0;
        }
        else
        {
            puntajeNuevo -= 150;
        }
        
        
    }

    public void SacaMiss()
    {
        vida -= 300;
        if (vida < 0)
        {
            vida = 0;
        }
        corazon.fillAmount = vida/ vidaMax;
        if ((puntajeNuevo - 300) <= 0)
        {
            puntajeNuevo = 0;
        }
        else
        {
            puntajeNuevo -= 300 ;
        }

    }

    public void Win()
    {
        WinUI.SetActive(true);
        WinUI.GetComponent<Button>().Select();
    }
}
