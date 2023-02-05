using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class activeSongMenu : MonoBehaviour
{
    public Song scriptableObject;

    public void PlaySong()
    {
        SceneManager.LoadScene(1);
    }
}
