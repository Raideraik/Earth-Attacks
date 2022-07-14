using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBattle : MonoBehaviour
{
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private Transform _spawnPoint;


    public void StartFight() 
    {
       Instantiate(_enemyTemplate, _spawnPoint);
    }
}
