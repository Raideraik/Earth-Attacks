using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(PauseMenu))]
public class GameMaster : MonoBehaviour
{
    [SerializeField] private GameOver _gameOverUI;
    [SerializeField] private TMP_Text _gameOverText;
    [SerializeField] private int _nextLevelNumber;
    [SerializeField] private GameObject _nextLevelButton;

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
        _spawner.AllEnemysDied += LevelVictory;
    }

    private void OnDisable()
    {
        _spawner.AllEnemysDied -= LevelVictory;
    }

    private void Update()
    {
        if (PlayerStats.Lives <= 0 && !_gameEnded)
        {
            EndGame();
        }
    }

    private void LevelVictory() 
    {
        _gameEnded = true;

        _gameOverText.text = "Victory";
        _gameOverText.color = Color.green;
        _gameOverUI.gameObject.SetActive(true);
        _nextLevelButton.SetActive(true);
        PlayerPrefs.SetInt("levelReached", _nextLevelNumber);

    }

    private void EndGame()
    {
        _gameEnded = true;

        _gameOverUI.gameObject.SetActive(true);
        _gameOverText.text = "GAME OVER";
        _gameOverText.color = Color.red;
        _nextLevelButton.SetActive(false);

        StartCoroutine(StopTime());
    }


    IEnumerator StopTime() 
    {
        yield return new WaitForSeconds(1f);

        Time.timeScale = 0;
    }
}
