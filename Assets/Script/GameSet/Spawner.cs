using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private int _countOfWaves;
    [SerializeField] private int _countEnemyInWave;

    private float _elapsedTime = 0;
    private int _waveIndex = 0;

    private void Start()
    {
        Initialize(_enemyTemplates);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_countOfWaves >= _waveIndex)
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
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }


}
