using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Toggle _fullScreen;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _volume;

    private void Start()
    {
        _audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));
        _volume.value = PlayerPrefs.GetFloat("Volume");
        Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullScreen"));
        _fullScreen.isOn = Screen.fullScreen;
    }

    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void SetFullScreen(bool isFullscreen) 
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("FullScreen", Convert.ToInt32(isFullscreen));
    }
}
