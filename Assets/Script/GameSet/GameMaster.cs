using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(PauseMenu))]
public class GameMaster : MonoBehaviour
{
    [SerializeField] private GameOver _gameOverUI;
    [SerializeField] private TMP_Text _gameOverText;

    private Spawner _spawner;
    private bool _gameEnded = false;

    public bool GameEnded => _gameEnded;
    private void Awake()
    {
        Time.timeScale = 1;
        _spawner = GetComponent<Spawner>();
    }

    private void OnEnable()
    {
        _spawner.AllEnemysDied += Victory;
    }

    private void OnDisable()
    {
        _spawner.AllEnemysDied -= Victory;
    }

    private void Update()
    {
        if (PlayerStats.Lives <= 0 && !_gameEnded)
        {
            EndGame();
        }
    }

    private void Victory() 
    {
        _gameEnded = true;

        _gameOverText.text = "Victory";
        _gameOverText.color = Color.green;
        _gameOverUI.gameObject.SetActive(true);

    }

    private void EndGame()
    {
        _gameEnded = true;

        _gameOverUI.gameObject.SetActive(true);
        _gameOverText.text = "GAME OVER";
        _gameOverText.color = Color.red;

        StartCoroutine(StopTime());
    }

    IEnumerator StopTime() 
    {
        yield return new WaitForSeconds(1f);

        Time.timeScale = 0;
    }
}
