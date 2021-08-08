using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    private void Awake() 
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start() 
    {
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
