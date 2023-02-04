using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class LoadSongs : MonoBehaviour
{
    public string levelToLoad;

    public int SelectedSong = 0;

    public string folderOfSongs = "Levels";
    public string folderOfSongsJson = "Songs.json";

    [Space(30f)]
    public string songDataJsonName = "data.json";
    public string songUserDataJsonName = "userData.json";

    [Space(30f)]
    [SerializeField]
    public string[] songsArray;

    [Space(30f)]
    [SerializeField]
    public SongData[] ListOfSongData;
    [SerializeField]
    public Dificulty[][] ListOfSongDificultyData;

    private void Start()
    {
        if(Sistema.data.loadSongs == null)
        {
            Sistema.data.loadSongs = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        LoadListOfSongs();
        LoadListOfSongsData();
        LoadListOfSongsDificultyData();
    }

    public void LoadListOfSongs()
    {
        LoadToJson();
    }

    public void LoadToJson()
    {
        string json = File.ReadAllText(Application.dataPath + "\\" + folderOfSongs + "\\" + folderOfSongsJson);
        songJSONData songRecord = JsonUtility.FromJson<songJSONData>(json);

        songsArray = songRecord.songs;

    }

    public void LoadListOfSongsData()
    {
        LoadToJson2();
    }

    public void LoadToJson2()
    {
        List<SongData> songDataList;
        songDataList = new List<SongData>();

        for (int i = 0; i < songsArray.Length; i++)
        {
            string json = File.ReadAllText(Application.dataPath + "\\" + folderOfSongs + "\\" + songsArray[i] + "\\" + songDataJsonName);
            //Debug.Log(json);
            SongData songDataRecord = JsonUtility.FromJson<SongData>(json);
            //Debug.Log(JsonUtility.ToJson(songDataRecord));
            songDataList.Add(songDataRecord);
        }


        //Debug.Log(JsonUtility.ToJson(songDataList));
        ListOfSongData = songDataList.ToArray();
        //Debug.Log(JsonUtility.ToJson(ListOfSongData));

    }

    public void LoadListOfSongsDificultyData()
    {
        LoadToJson3();
    }

    public void LoadToJson3()
    {

        List < List<Dificulty> > listaDeCanciones;
        listaDeCanciones = new List<List<Dificulty>>();

        for (int i = 0; i < ListOfSongData.Length; i++)
        {
            List<Dificulty> dificultadesDeLaCancion;
            dificultadesDeLaCancion = new List<Dificulty>();
            listaDeCanciones.Add(dificultadesDeLaCancion);

            for (int j = 0; j < ListOfSongData[i].dificulty.Length; j++)
            {
                string json = File.ReadAllText(Application.dataPath + "\\" + folderOfSongs + "\\" + songsArray[i] + "\\" + ListOfSongData[i].dificulty[j] + ".json");
                Dificulty songDatadificultyRecord = JsonUtility.FromJson<Dificulty>(json);
                dificultadesDeLaCancion.Add(songDatadificultyRecord);

            }

        }

        var result = listaDeCanciones.Select(x => x.ToArray()).ToArray();
        ListOfSongDificultyData = result;
        //Debug.Log(JsonUtility.ToJson(result, true));
    }
}

[SerializeField]
public class songJSONData
{
    public string[] songs;
}

[SerializeField]
public class songFolderData
{
    public string FolderName;
}

[SerializeField]
public class SongData
{
    public string songName;
    public string music;
    public string artist;
    public string[] dificulty;
}

[SerializeField]
public class Dificulty
{
    public int[] numCircle;
    public int[] sample;
    public float level;
}