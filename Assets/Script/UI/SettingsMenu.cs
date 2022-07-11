using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Toggle _fullScreen;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _volume;
    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    private Resolution[] _resolutions;



    private void Start()
    {
        _resolutions = Screen.resolutions;

        _resolutionDropdown.ClearOptions();

        List<String> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + " x " + _resolutions[i].height;
            options.Add(option);

            if (_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.value = currentResolutionIndex;
        _resolutionDropdown.RefreshShownValue();




        _audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));
        _volume.value = PlayerPrefs.GetFloat("Volume");
        _fullScreen.isOn = Screen.fullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void SetFullScreen(bool isFullscreen) 
    {
        Screen.fullScreen = isFullscreen;
    }
}
