using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : ObjectPool
{

    [SerializeField] private GameObject[] _enemyTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private int _countOfWaves;
    [SerializeField] private int _countEnemyInWave;

    public static int _enemyAlive = 0;
    public event UnityAction AllEnemysDied;

    private float _elapsedTime = 0;
    private int _waveIndex = 0;

    private void Start()
    {
        Initialize(_enemyTemplates);
        InvokeRepeating("EndLevel", 0f, 1f);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_countOfWaves >= _waveIndex+1)
        {
            if (_elapsedTime > _secondsBetweenSpawn)
            {
                _waveIndex++;
                StartCoroutine(SetWave());
            }
        }
    }
    IEnumerator SetWave()
    {
        for (int i = 0; i < _countEnemyInWave; i++)
        {

            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);

            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        _enemyAlive++;
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
