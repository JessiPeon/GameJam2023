using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControlF : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private List<int> numCircle;
    private List<long> sample;
    private SaveTime script;

    private void Awake()
    {
        script = gameObject.GetComponent<SaveTime>();
        numCircle = script.numCircle;
        sample = script.sample;

    }
    public void OnMusic()
    {
        audioSource.Play();
        if (sample.Count == 0) {
            
        }
    }
    public void OffMusic()
    {
        audioSource.Stop();
    }

}
