using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum soundsGame{
    die,
    toque,
    menu,
    point,
    wing
}

public class SoundController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip soundDie;
    public AudioClip soundToque;
    public AudioClip soundMenu;
    public AudioClip soundPoint;
    public AudioClip soundWing;
 
    public static SoundController instance;

    void Start()
    {
        instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(soundsGame currentSound)
    {
        switch(currentSound)
        {
            case soundsGame.die:
                // AudioSource.PlayOneShot(soundDie);
                // audioSource.PlayOneShot(success);
                
                break;
        }
    }
}
