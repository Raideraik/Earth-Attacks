using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _volume;

    private void Start()
    {
        _audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));
        _volume.value = PlayerPrefs.GetFloat("Volume");
    }

    public void SetVolume()
    {
        float volume = _volume.value;
        _audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
