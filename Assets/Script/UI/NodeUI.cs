using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    [SerializeField] private Canvas _uI;
    [SerializeField] private TMP_Text _upgradeText;
    [SerializeField] private Button _upgradeButton;

    [SerializeField] private TMP_Text _sellText;

    private Node _target;
    private BuildManager _buildManager;

    private void Start()
    {
        _buildManager = BuildManager.Instance;
    }

    public void SetTarget(Node target)
    {
        _target = target;

        transform.position = target.GetBuildPosition();

        if (!_target.IsUpgraded)
        {
            _upgradeText.text = "Upgrade \n" + _target.Blueprint.UpgradeCost.ToString();
            _upgradeButton.interactable = true;

        }
        else
        {
            _upgradeText.text = "Maximum";
            _upgradeButton.interactable = false;
        }
        _sellText.text = "Sell \n" + _target.Blueprint.GetSellAmount().ToString();


        _uI.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _uI.gameObject.SetActive(false);
    }

    public void Upgrade()
    {
        _target.UpgradeTurret();
        _buildManager.DeselectNode();
        _upgradeText.text = "Upgrade /n" + _target.Blueprint.UpgradeCost.ToString();

    }

    public void Sell()
    {
        _target.SellTurret();
        _buildManager.DeselectNode();
    }

}
