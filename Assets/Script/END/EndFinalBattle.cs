using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFinalBattle : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private int _levelNumber;
    private Collider _collider;

    private void Start()
    {
       _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
       
            _sceneFader.FadeTo(_levelNumber);
        PlayerPrefs.SetInt("levelReached", 12);

    }

}
