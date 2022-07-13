using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Spawner : ObjectPool
{

    [SerializeField] private Enemy[] _enemyTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private bool _endless;
    [SerializeField] private int _countOfWaves;
    [SerializeField] private int _countEnemyInWave;
    [SerializeField] private Slider _slider;

    public static int _enemyAlive = 0;
    public event UnityAction AllEnemysDied;

    private float _elapsedTime = 0;
    private int _waveIndex = 0;



    private void Start()
    {
        if (_endless)
        {
            _countOfWaves = int.MaxValue;
        }


        _enemyAlive = _countEnemyInWave * _countOfWaves;
        Initialize(_enemyTemplates);
        InvokeRepeating("EndLevel", 0f, 1f);
        _slider.maxValue = _secondsBetweenSpawn;
    }

    private void Update()
    {
        if (_countOfWaves == _waveIndex)
            _slider.value = _slider.maxValue;
        else
            _slider.value = _elapsedTime;

        _elapsedTime += Time.deltaTime;
        if (_countOfWaves >= _waveIndex+1)
        {
            if (_elapsedTime > _secondsBetweenSpawn)
            {
                _waveIndex++;
                StartCoroutine(SetWave());
                _elapsedTime = 0;
            }
        }
        
    }
    IEnumerator SetWave()
    {
        for (int i = 0; i < _countEnemyInWave; i++)
        {

            if (TryGetObject(out GameObject enemy))
            {

                int spawnPointNumber = UnityEngine.Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);

            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private void EndLevel()
    {
        if (_countOfWaves == _waveIndex && _enemyAlive <= 0)
        {
            AllEnemysDied?.Invoke();
        }
    }
}
