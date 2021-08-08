using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    public AudioSource audioSource;
    public AudioClip mainEngine;
    public AudioClip successSFX;
    public AudioClip crashSoundSFX;
    private float musicVolume = 1f;

    private void Start() 
    {
        instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    private void Update() 
    {
        audioSource.volume = musicVolume;
    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }

    public void ThrustingSound()
    {
        if (!audioSource.isPlaying)
        {
            // Dont add audioSource.Stop(); this will prevent other sounds from playing while thrusting
            audioSource.PlayOneShot(mainEngine);
        }
    }

    public void SuccessSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(successSFX);
    }

    public void CrashSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(crashSoundSFX);
    }
    
}
