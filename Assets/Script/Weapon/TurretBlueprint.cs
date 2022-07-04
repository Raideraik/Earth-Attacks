using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint 
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _cost;

    public GameObject Prefab => _prefab;
    public int Cost => _cost;

}
