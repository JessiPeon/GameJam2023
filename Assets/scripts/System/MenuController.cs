using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    public Song[] songs;
    public GameObject prefab;

    void Start()
    {
        GameObject content = GameObject.Find("Content");
        for (int i = 0; i < songs.Length; i++)
        {
            GameObject song = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity, content.transform);
            song.GetComponent<Image>().sprite = songs[i].spriteMenuSong;
            song.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = songs[i].name;
            song.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = songs[i].difficulty.ToString();
            song.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
    }

    void Update()
    {
        
    }
}
