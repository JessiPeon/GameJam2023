using System;
using System.Collections;
using System.Collections.Generic;
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
}
