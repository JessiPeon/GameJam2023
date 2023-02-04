using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControlF : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private Controls controls;
    private List<int> numCircle;
    private List<long> sample;
    private SaveTime script;
    private bool play;
    private int i = 0;

    private void Awake()
    {
        script = gameObject.GetComponent<SaveTime>();
        controls = gameObject.GetComponent<Controls>();
    }
    private void Update()
    {
        if (play) { 
            if (script.sample.Count >0 && script.sample.Count >= i)
            {
                if (audioSource.timeSamples >= script.sample[i])
                {
                    controls.IluminaCirculo(script.numCircle[i]);
                    i++;
                }
            }
            else
            {
                i = 0;
            }
        }
    }
    public void OnMusic()
    {
        audioSource.Play();
        if (script.sample.Count == 0) {
            script.LoadToJson();
        }
        play = true;
    }
    public void OffMusic()
    {
        audioSource.Stop();
        play = false;
    }

}
