using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform _enemyTemplate;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _timeBetweenWaves = 5f;
    [SerializeField] private TMP_Text _CountDownText;

    private float _countDown = 2f;

    private int _waveIndex = 0;

    private void Update()
    {
        if (_countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countDown = _timeBetweenWaves;
        }

        _countDown -= Time.deltaTime;

        _CountDownText.text = Mathf.Round(_countDown).ToString();

    }

    IEnumerator SpawnWave() 
    {

        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(0.5f);
        }

        _waveIndex++;
    }

    private void SpawnEnemy() 
    {
        Instantiate(_enemyTemplate, _spawnPoint.position, _spawnPoint.rotation);
    }

}
