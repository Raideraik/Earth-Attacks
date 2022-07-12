using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TurretBlueprint", menuName = "CreateBlueprint")]
public class TurretBlueprint:ScriptableObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _upgradedPrefab;
    [SerializeField] private int _cost;
    [SerializeField] private int _upgradeCost;
    [SerializeField] private string _description;

    public GameObject Prefab => _prefab;
    public GameObject UpgradedPrefab => _upgradedPrefab;

    public int Cost => _cost;
    public int UpgradeCost => _upgradeCost;

    public string Description => _description;

    public int GetSellAmount() 
    {
        return _cost / 2;
    }

}
