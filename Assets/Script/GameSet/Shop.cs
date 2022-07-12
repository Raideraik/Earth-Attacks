using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    //[SerializeField] private GameObject[] _standartTurretPrefab;
    [SerializeField] private TurretBlueprint[] _turretBlueprint;
    [SerializeField] private GameObject _descriptionBG;
    [SerializeField] private TMP_Text _descriptionText;

    private BuildManager _buildManager;

    [SerializeField] private TMP_Text[] _costText;


    private void OnMouseEnter()
    {
        _descriptionBG.SetActive(true);
    }

    private void Start()
    {
        _buildManager = BuildManager.Instance;
        for (int i = 0; i < _costText.Length; i++)
        {
            _costText[i].text = _turretBlueprint[i].Cost.ToString();
        }
    }

    public void SelectTurret(int number) 
    {
            _buildManager.SelectTurretToBuild(_turretBlueprint[number]);
        _descriptionText.text = _turretBlueprint[number].Description;

    }
}
