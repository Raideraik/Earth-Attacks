using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private GameObject _buildEffect;

    private TurretBlueprint _turretTobuild;

    public static BuildManager Instance;
    public bool CanBuild { get { return _turretTobuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= _turretTobuild.Cost; } }


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }

        Instance = this;
    }
    /*
    private void Start()
    {
        _turretTobuild = _standartTurretPrefab;
    }*/


    public void SelectTurretToBuild(TurretBlueprint turret) 
    {
        _turretTobuild = turret;
    }

    public void BuildTurretOn(Node node) 
    {
        // GameObject turretToBuild = _buildManager.GetTurretToBuild();
        if (PlayerStats.Money < _turretTobuild.Cost)
        {
            Debug.Log("Not Enough money");
            return;
        }

        PlayerStats.Money -= _turretTobuild.Cost;

        GameObject turret = (GameObject)Instantiate(_turretTobuild.Prefab, node.GetBuildPosition(), Quaternion.identity);

        node.Turret = turret;

        GameObject effect = (GameObject)Instantiate(_buildEffect, node.GetBuildPosition(), Quaternion.identity);

        Destroy(effect, 5f);
    }
}
