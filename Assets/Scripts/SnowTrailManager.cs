using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTrailManager : MonoBehaviour
{
    private AudioSource snowTrailAudio;
    void Start()
    {
        snowTrailAudio = GetComponent<AudioSource>();
    }

    public void turnOnSnowTrailAudio()
    {
        snowTrailAudio.Play();
    }

    public void turnOffSnowTrailAudio()
    {
        snowTrailAudio.Stop();
    }
}

