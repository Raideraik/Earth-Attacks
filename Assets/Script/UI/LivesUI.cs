using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    private TMP_Text _livesText;

    private void Start()
    {
        _livesText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _livesText.text = PlayerStats.Lives.ToString() + " Lives";
    }
}
