using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    private TMP_Text _moneyText;

    private void Start()
    {
        _moneyText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _moneyText.text =PlayerStats.Money.ToString();
    }
}
