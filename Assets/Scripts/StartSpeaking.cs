using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpeaking : MonoBehaviour
{
    public AudioClip SoundToPlay;

    public float Volume;

    private AudioSource audio;

    public bool alreadyPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (!alreadyPlayed)
        {
            audio.PlayOneShot(SoundToPlay, Volume);
            alreadyPlayed = true; 
        }
    }
}
