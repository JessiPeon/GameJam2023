using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistema : MonoBehaviour
{
    public static Sistema data;

    public PoolBichos poolBichos = null;
    public MusicTimer musicTimer = null;


    public LoadSongs loadSongs = null;
    public LoadSongData loadSongData = null;

    public RenderSong renderSong = null;


    // Start is called before the first frame update
    void Awake()
    {

        //generando un singleton
        if(data == null)
        {
            Debug.Log(this.gameObject.name + "(" + this.gameObject.GetInstanceID() + ") - soy el sistema");
            data = this;
        }
        else{
            if(data != this)
            {
                Debug.Log(this.gameObject.name + "(" + this.gameObject.GetInstanceID() + ") - ya hay otro sistema, es " + Sistema.data.gameObject.name + "(" + Sistema.data.gameObject.GetInstanceID() + ")" );
                Destroy(this);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
