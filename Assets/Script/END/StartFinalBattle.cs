using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFinalBattle : MonoBehaviour
{
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private Transform _spawnPoint;

    private void Start()
    {
        _enemyTemplate.gameObject.SetActive(false);
    }

    public void StartFight() 
    {
        _enemyTemplate.gameObject.SetActive(true);
        _enemyTemplate.transform.position = _spawnPoint.position;
    }
}
