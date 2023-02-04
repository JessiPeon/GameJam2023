using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Song", menuName = "ScriptableObjects/Song")]
public class Song : ScriptableObject
{
    public string nameSong;
    public int difficulty;
    public Sprite spriteMenuSong;
}
