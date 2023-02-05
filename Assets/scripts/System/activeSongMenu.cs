using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class activeSongMenu : MonoBehaviour
{
    public Song scriptableObject;
    public Button boton;

    public void PlaySong()
    {
        SceneManager.LoadScene(1);
    }

    public void Start()
    {
        boton.Select();
    }

}
