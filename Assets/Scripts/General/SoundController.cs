using UnityEngine;

public class SoundController : MonoBehaviour
{
    [Header("Audio Sourcers")] 
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource soundtrackSource;

    [Header("Audio Clips")] 
    [SerializeField] private AudioClip flySfx;
    [SerializeField] private AudioClip deathSfx;
    [SerializeField] private AudioClip soundtrack;

    //Making this a Singleton for now, idk if a Interface is necessary/a good practice
    public static SoundController Instance { get; private set; }

    private void Awake() 
    { 
        // Singleton setup
        if (Instance != null && Instance != this) { Destroy(this); } else { Instance = this; } 
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
