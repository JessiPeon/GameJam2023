using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveTime : MonoBehaviour
{

    public List<int> numCircle = new List<int>();
    public List<long> sample = new List<long>();
    public int level = 1;
    [SerializeField] private AudioSource audioSource;

    private void OnEnable()
    {
        Controls.saveTime += save;
    }

    private void OnDisable()
    {
        Controls.saveTime -= save;
    }

    public void save(int number)
    {
        numCircle.Add(number);
        sample.Add(audioSource.timeSamples);
        SaveToJson();
        Debug.Log(numCircle.ToString() + " " + audioSource.timeSamples.ToString());
    }

    public void load(int number)
    {
        LoadToJson();
    }

    public void SaveToJson()
    {
        Record record = new Record();
        record.numCircle = numCircle;
        record.sample = sample;

        string json = JsonUtility.ToJson(record, true);
        File.WriteAllText(Application.dataPath + "/records.json", json);
    }
    public void SaveToJson2()
    {
        Cancion record = new Cancion();
        record.level = 1;
        record.notas = new List<Nota>();
        for (int i = 0; i < sample.Count; i++)
        {
            Nota nota = new Nota();
            nota.numCircle = numCircle[i];
            nota.sample = (int)sample[i];
            record.notas.Add(nota);
        }

        string json = JsonUtility.ToJson(record, true);
        File.WriteAllText(Application.dataPath + "/records2.json", json);
    }
    public void LoadToJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/records.json");
        Record record = JsonUtility.FromJson<Record>(json);

        numCircle = record.numCircle;
        sample =record.sample;
        level = record.level;
    }

    
}

[System.Serializable]
public class Nota
{
    public int numCircle;
    public int sample;

    
}


[System.Serializable]
public class Cancion
{
    public List<Nota> notas;
    public int level;
}