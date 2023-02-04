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
    public List<int> indices;

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

        indices = new List<int>
        {
            0,
            0,
            0,
            0,
        };
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
        int? hitPlus = null;
        int? hitMinus = null;
        int i = 0;
        var circle = listaCircles[indice];
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
        var minusResult = CalculateHit(sapmleToFind, hitMinus);
        if (minusResult)
        {
            Sistema.data.poolBichos.destoryBicho(indice, hitMinus.GetValueOrDefault());
            return true;
        }
        var plusResult = CalculateHit(sapmleToFind, hitPlus);
        if (plusResult)
        {
            Sistema.data.poolBichos.destoryBicho(indice, hitPlus.GetValueOrDefault());
            return true;
        }
        return false;
    }

    private bool CalculateHit(int sapmleToFind, int? hitMinus)
    {
        var difference = Mathf.Abs(sapmleToFind - hitMinus.GetValueOrDefault());
        if (hitMinus is null || difference > sampleBad)
        {
            return false;
        }
        if (difference <= samplePerfect)
        {
            Debug.Log("Perfect");
            //llamar perfect
            return true;
        }
        if (difference <= sampleGood)
        {
            Debug.Log("Good");
            //llamar good
            return true;
        }
        if (difference <= sampleOk)
        {
            Debug.Log("OK");
            //llamar ok
            return true;
        }
        //llamar bad
        Debug.Log("Bad");
        return true;
    }
}
