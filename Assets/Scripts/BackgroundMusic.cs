using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
     private static BackgroundMusic instance = null;
    public static BackgroundMusic Instance { get { return instance; } }
    [SerializeField] Slider volumeSlider;
    AudioSource audioSource;
    // private void Awake() 
    // {
    //     instance = this;
    //     DontDestroyOnLoad(gameObject);
    // }
    void Awake() {
    if (instance != null) 
    {
        Destroy(this.gameObject);
        return;
    } 
    else 
    {
        instance = this;
    }
    DontDestroyOnLoad(this.gameObject);
 }

    private void Start() 
    {
        // Fix issue of music doubling on route to menu from any scene
        PlayerPrefs.SetFloat("musicVolume", 1);
        LoadVolume();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }

    private void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
