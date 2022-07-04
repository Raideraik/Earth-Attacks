using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Color _notEnoughMoney;
    [SerializeField] private Vector3 _positionOffset;

    public GameObject Turret;

    private Renderer _renderer;
    private Color _startColor;
    private BuildManager _buildManager;


    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
        _buildManager = BuildManager.Instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!_buildManager.CanBuild)
            return;

        if (Turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen");
            return;
        }



        _buildManager.BuildTurretOn(this);

    }

    private void OnMouseEnter()
    {
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

    public Vector3 GetBuildPosition()
    {
        return transform.position + _positionOffset;
    }
}
