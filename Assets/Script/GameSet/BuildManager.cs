using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private GameObject _buildEffect;
    [SerializeField] private GameObject _sellEffect;
    [SerializeField] private NodeUI _nodeUI;

    private TurretBlueprint _turretTobuild;
    private Node _selectedNode;

    public static BuildManager Instance;
    public bool CanBuild { get { return _turretTobuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= _turretTobuild.Cost; } }

    public GameObject BuildEffect => _buildEffect;
    public GameObject SellEffect => _sellEffect;

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


    public void DeselectNode() 
    {
        _selectedNode = null;
        _nodeUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild() 
    {
        return _turretTobuild;
    }

    public void SelectNode(Node node) 
    {
        if (_selectedNode == node)
        {
            DeselectNode();
            return;
        }

        _selectedNode = node;
        _turretTobuild = null;

        _nodeUI.SetTarget(node);
    }


    public void SelectTurretToBuild(TurretBlueprint turret) 
    {
        _turretTobuild = turret;
        _selectedNode = null;

        DeselectNode();

    }
}
