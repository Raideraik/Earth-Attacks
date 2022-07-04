using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject[] _standartTurretPrefab;

    private BuildManager _buildManager;

    private void Start()
    {
        _buildManager = BuildManager.Instance;
    }

    public void PurchaseStandardTurret(int number) 
    {
            _buildManager.SetTurretToBuild(_standartTurretPrefab[number]);
    }
}
