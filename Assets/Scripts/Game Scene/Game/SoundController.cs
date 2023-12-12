using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [Header("Audio Sourcers")] 
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource soundtrackSource;

    [Header("Audio Clips")] 
    [SerializeField] AudioClip flySfx;
    [SerializeField] AudioClip deathSfx;
    [SerializeField] AudioClip soundtrack;

    //Making this a Singleton for now, idk if a Interface is necessary/a good practice
    public static SoundController Instance { get; private set; }

    void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public void PlayFlySFX()
    {
        sfxSource.clip = flySfx;
        sfxSource.Play();
    }

    public void PlayDeathSFX()
    {
        sfxSource.clip = deathSfx;
        sfxSource.Play();
    }

    public void PauseSoundtrack()
    {
        soundtrackSource.clip = soundtrack;
        sfxSource.Pause();
    }

    public void ResumeSoundtrack()
    {
        soundtrackSource.clip = soundtrack;
        sfxSource.Play();
    }
}
