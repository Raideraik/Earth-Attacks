using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject _turretTobuild;

    public static BuildManager Instance;
    public GameObject GetTurretToBuild() 
    {
        return _turretTobuild;
    }

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

    public void SetTurretToBuild(GameObject turret) 
    {
        _turretTobuild = turret;
    }
}
