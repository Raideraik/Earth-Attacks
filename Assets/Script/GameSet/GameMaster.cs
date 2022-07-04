using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    private bool _gameEnded = false;

    private void Update()
    {
        if (PlayerStats.Lives <= 0 && !_gameEnded)
        {
            EndGame();
        }
    }

    private void EndGame() 
    {
        _gameEnded = true;
        Debug.Log("Game Over");
    }
}
