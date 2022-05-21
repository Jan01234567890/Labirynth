using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] clips;
    int currentClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        currentClip = 0;
        audioSource.clip = clips[currentClip];
        audioSource.Play();
    }

    private void Update()
    {
        if(audioSource.time >= clips[currentClip].length)
        {
            currentClip++;
            if(currentClip >clips.Length - 1)
            {
                currentClip = 0;
            }
            audioSource.clip = clips[currentClip];
            audioSource.Play();
        }
    }

    public void OnGamePaused()
    {
        audioSource.Pause();
    }
    public void OnGameResumed()
    {
        audioSource.UnPause();
    }

    public void Pitch(float pitch)
    {
        audioSource.pitch = pitch;
    }
}
