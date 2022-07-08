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
        if (PlayerStats.Lives <= 0)
            PlayerStats.Lives = 0;
        
            _livesText.text = PlayerStats.Lives.ToString();


    }
}
