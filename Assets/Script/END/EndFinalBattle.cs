using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFinalBattle : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private int _levelNumber;
    [SerializeField] private GameObject _deathEffect;

    private AudioSource _audio;
    private Collider _collider;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _audio.Play();
        Instantiate(_deathEffect, transform.position, Quaternion.identity);

        _sceneFader.FadeTo(_levelNumber);
        PlayerPrefs.SetInt("levelReached", 12);

    }

}
