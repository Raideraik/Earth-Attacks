using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private GameOver _gameOverUI;

    private bool _gameEnded = false;


    private void Start()
    {
        Time.timeScale = 1;
    }

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

        _gameOverUI.gameObject.SetActive(true);

        StartCoroutine(StopTime());
    }

    IEnumerator StopTime() 
    {
        yield return new WaitForSeconds(1f);

        Time.timeScale = 0;
    }
}
