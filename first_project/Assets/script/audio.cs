using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{

    public AudioClip[] playlist; 
    public AudioSource audioSource;
    private int musicindex = 0; 

    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    void Update()
    {
        if(!audioSource.isPlaying)
        {
            playNextSong(); 
        }
    }

    void playNextSong()
    {
        musicindex=(musicindex+1)%playlist.Length;
        audioSource.clip= playlist[musicindex];
        audioSource.Play(); 
    }

}
