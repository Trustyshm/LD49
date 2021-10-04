using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;


    private void Awake()
    {
        masterSlider.value = GetVolume("MasterVolume");
        musicSlider.value = GetVolume("MusicVolume");
        sfxSlider.value = GetVolume("SFXVolume");
       // SetMaster(GetVolume("MasterVolume"));
       // SetMusic(GetVolume("MusicVolume"));
       // SetSFX(GetVolume("SFXVolume"));


    }

    public void SetMaster (float volume)
    {

        audioMixer.SetFloat("MasterVolume", volume);

    }

    public void SetMusic(float volume)
    {

        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSFX(float volume)
    {

        audioMixer.SetFloat("SFXVolume", volume);
    }

    private float GetVolume (string volume)
    {
        if (audioMixer.GetFloat(volume, out float newVal))
        {
            return newVal;
        }
        else
        {
            return 0;
        }
    }



}
