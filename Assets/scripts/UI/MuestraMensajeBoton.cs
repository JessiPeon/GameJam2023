using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuestraMensajeBoton : MonoBehaviour
{

    public Image boton1;
    public Image boton2;
    public Image boton3;
    public Image boton4;

    public GameObject instanciaPerfect;
    public GameObject instanciaGood;
    public GameObject instanciaOk;
    public GameObject instanciaBad;
    public GameObject instanciaMiss;

    public GameObject instanciaExplocion;

    private void Start()
    {
        if(Sistema.data.muestraMensajeBoton == null)
        {
            Sistema.data.muestraMensajeBoton = this;
        }
    }

    public void instanciarBotonEfect(int botton, int puntos)
    {
        switch (botton)
        {
            case 1:
                instanciarEfecto(boton1, puntos);
                break;
            case 2:
                instanciarEfecto(boton2, puntos);
                break;
            case 3:
                instanciarEfecto(boton3, puntos);
                break;
            case 4:
                instanciarEfecto(boton4, puntos);
                break;
        }
    }

    public void instanciarEfecto(Image boton, int puntos)
    {
        GameObject imagenInstanciada;
        switch (puntos)
        {
            case 1:
                imagenInstanciada = Instantiate(instanciaPerfect, boton.transform);
                break;
            case 2:
                imagenInstanciada = Instantiate(instanciaGood, boton.transform);
                break;
            case 3:
                imagenInstanciada = Instantiate(instanciaOk, boton.transform);
                break;
            case 4:
                imagenInstanciada = Instantiate(instanciaBad, boton.transform);
                break;
            case 5:
                imagenInstanciada = Instantiate(instanciaMiss, boton.transform);
                break;

        }

        GameObject imagenInstanciada2 = Instantiate(instanciaExplocion, boton.transform);
        Destroy(imagenInstanciada2, 0.25f);
    }
}
