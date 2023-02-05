using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSongData : MonoBehaviour
{
    public int songSelected;
    public int lastSongSelected;

    public int songNumber = 0;
    public int songDificulty = 0;

    public SongData selectedSongData;
    public Dificulty selectedSongDificultyData;

    // Start is called before the first frame update
    void Start()
    {

        if (Sistema.data.loadSongData == null)
        {
            Sistema.data.loadSongData = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        selectedSongData = Sistema.data.loadSongs.ListOfSongData[songNumber];
        selectedSongDificultyData = Sistema.data.loadSongs.ListOfSongDificultyData[songNumber][songDificulty];

        //Debug.Log("CANCION SELECCIONADA");
        //Debug.Log(JsonUtility.ToJson(selectedSongData));
        //Debug.Log(JsonUtility.ToJson(selectedSongDificultyData));
    }

    // Update is called once per frame
    void Update()
    {

    }
}

