using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Color _notEnoughMoney;
    [SerializeField] private Vector3 _positionOffset;

    [SerializeField] private bool _BuildProhibition;

    private Renderer _renderer;
    private GameObject _turret;
    private TurretBlueprint _turretBlueprint;
    private bool _isUpgraded;

    private Color _startColor;
    private BuildManager _buildManager;

    public TurretBlueprint Blueprint => _turretBlueprint;
    public bool IsUpgraded => _isUpgraded;

    private void Start()
    {
        _renderer = transform.GetComponent<Renderer>();

        _startColor = _renderer.material.color;
        _buildManager = BuildManager.Instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (_turret != null)
        {
            _buildManager.SelectNode(this);
            return;
        }

        if (!_buildManager.CanBuild)
            return;


        BuildTurret(_buildManager.GetTurretToBuild());

    }

    private void OnMouseEnter()
    {
        if (_BuildProhibition)
            return;

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!_buildManager.CanBuild)
            return;

        if (_buildManager.HasMoney)
            _renderer.material.color = _hoverColor;
        else
            _renderer.material.color = _notEnoughMoney;

    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }

    private void BuildTurret(TurretBlueprint blueprint)
    {
        // GameObject turretToBuild = _buildManager.GetTurretToBuild();
        if (_BuildProhibition)
            return;

        if (PlayerStats.Money < blueprint.Cost)
        {
            //Debug.Log("Not Enough money");
            return;
        }

        PlayerStats.Money -= blueprint.Cost;

        GameObject turret = (GameObject)Instantiate(blueprint.Prefab, GetBuildPosition(), Quaternion.identity);
        _turret = turret;

        _turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(_buildManager.BuildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void UpgradeTurret()
    {
        // GameObject turretToBuild = _buildManager.GetTurretToBuild();
        if (PlayerStats.Money < _turretBlueprint.UpgradeCost)
        {
            // Debug.Log("Not Enough money to Upgrade");
            return;
        }

        PlayerStats.Money -= _turretBlueprint.UpgradeCost;

        Destroy(_turret);

        GameObject turret = (GameObject)Instantiate(_turretBlueprint.UpgradedPrefab, GetBuildPosition(), Quaternion.identity);
        _turret = turret;


        GameObject effect = (GameObject)Instantiate(_buildManager.BuildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        _isUpgraded = true;

    }

    public void SellTurret()
    {
        PlayerStats.Money += _turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(_buildManager.SellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(_turret);
        _turretBlueprint = null;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + _positionOffset;
    }
}
