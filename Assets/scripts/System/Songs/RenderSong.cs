using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RenderSong : MonoBehaviour
{
    public int[] circle1;
    public int[] circle2;
    public int[] circle3;
    public int[] circle4;

    public List<int[]> listaCircles;
    public List<int[]> listaCirclesCheck;
    public List<int> indices;

    private ResultadoNota resultadoScript;

    // Start is called before the first frame update
    void Start()
    {
        if(Sistema.data.renderSong == null)
        {
            Sistema.data.renderSong = this;
        }
        else
        {
            if (Sistema.data.renderSong != this)
            {
                Destroy(this.gameObject);
            }
        }
        
        List<int> listaCircle1 = new List<int>();
        List<int> listaCircle2 = new List<int>();
        List<int> listaCircle3 = new List<int>();
        List<int> listaCircle4 = new List<int>();

        for (int i = 0; i < Sistema.data.loadSongData.selectedSongDificultyData.numCircle.Length; i++)
        {
            switch (Sistema.data.loadSongData.selectedSongDificultyData.numCircle[i])
            {
                case 1:
                    listaCircle1.Add(Sistema.data.loadSongData.selectedSongDificultyData.sample[i]);
                    break;
                case 2:
                    listaCircle2.Add(Sistema.data.loadSongData.selectedSongDificultyData.sample[i]);
                    break;
                case 3:
                    listaCircle3.Add(Sistema.data.loadSongData.selectedSongDificultyData.sample[i]);
                    break;
                case 4:
                    listaCircle4.Add(Sistema.data.loadSongData.selectedSongDificultyData.sample[i]);
                    break;

            }
        }

        circle1 = listaCircle1.ToArray();
        circle2 = listaCircle2.ToArray();
        circle3 = listaCircle3.ToArray();
        circle4 = listaCircle4.ToArray();

        listaCircles = new List<int[]>
        {
            circle1,
            circle2,
            circle3,
            circle4,
        };

        int[] circle1Check = new int[circle1.Length];
        int[] circle2Check = new int[circle2.Length];
        int[] circle3Check = new int[circle3.Length];
        int[] circle4Check = new int[circle4.Length];

        listaCirclesCheck = new List<int[]>
        {
            circle1Check,
            circle2Check,
            circle3Check,
            circle4Check,
        };



        indices = new List<int>
        {
            0,
            0,
            0,
            0,
        };

        resultadoScript = gameObject.GetComponent<ResultadoNota>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < listaCircles.Count; i++)
        {
            if (listaCircles[i].Length <= indices[i])
            {
                continue;
            }
            var sample = listaCircles[i][indices[i]];
            if (sample - Sistema.data.musicTimer.samplesToSpawn - 1882 <= Sistema.data.musicTimer.Samples)
            {
                //Sistema.data.spwnservice.spawnBichoAt(i);
                Sistema.data.poolBichos.intentarPool(i, sample);
                indices[i]++;
            }
        }
    }

    [Space(20f)]
    //public int samplePerfect = 2300;
    //public int sampleGood = 4500;
    //public int sampleOk = 5200;
    //public int sampleBad = 6000;

    public int samplePerfect = 2300;
    public int sampleGood = 4500;
    public int sampleOk = 5200;
    public int sampleBad = 6000;

    public bool CheckButtonPress(int indice, int sapmleToFind)
    {
        Debug.Log("se pidio el " + indice + " sample " + sapmleToFind);
        int? hitPlus = null;
        int? hitMinus = null;


        int i = 0;
        var circle = listaCircles[indice];
        var circleCheck = listaCirclesCheck[indice];

        for (; i < circle.Length; i++)
        {
            int item = circle[i];
            if (item >= sapmleToFind)
            {
                hitPlus = item;

                break;
            }
        }
        if (i != 0)
        {
            hitMinus = circle[i - 1];
        }
        
        if(i != 0)
        {
            if (listaCirclesCheck[indice][i - 1] != 1)
            {

                var minusResult = CalculateHit(sapmleToFind, hitMinus, indice);
                if (minusResult)
                {
                    listaCirclesCheck[indice][i - 1] = 1;
                    Sistema.data.poolBichos.destoryBicho(indice, hitMinus.GetValueOrDefault());
                    return true;
                }
            }
        }
        

        if (listaCirclesCheck[indice][i] != 1)
        {
            //listaCirclesCheck[indice][i] = 1;
            var plusResult = CalculateHit(sapmleToFind, hitPlus, indice);
            if (plusResult)
            {
                listaCirclesCheck[indice][i] = 1;
                Sistema.data.poolBichos.destoryBicho(indice, hitPlus.GetValueOrDefault());
                return true;
            }
        }

        
        return false;
    }

    private bool CalculateHit(int sapmleToFind, int? hitMinus, int indice)
    {
        var difference = Mathf.Abs(sapmleToFind - hitMinus.GetValueOrDefault());
        if (hitMinus is null || difference > sampleBad)
        {
            return false;
        }
        if (difference <= samplePerfect)
        {
            //Debug.Log("Perfect");
            Sistema.data.muestraMensajeBoton.instanciarBotonEfect(indice + 1, 1);
            resultadoScript.SacaPerfect();
            //llamar perfect
            return true;
        }
        if (difference <= sampleGood)
        {
            //Debug.Log("Good");
            Sistema.data.muestraMensajeBoton.instanciarBotonEfect(indice + 1, 2);
            resultadoScript.SacaGood();
            //llamar good
            return true;
        }
        if (difference <= sampleOk)
        {
            //Debug.Log("OK");
            //llamar ok
            Sistema.data.muestraMensajeBoton.instanciarBotonEfect(indice + 1, 3);
            resultadoScript.SacaOK();
            return true;
        }
        //llamar bad
        Sistema.data.muestraMensajeBoton.instanciarBotonEfect(indice + 1, 4);
        resultadoScript.SacaBad();
        //Debug.Log("Bad");
        return true;
    }
}
