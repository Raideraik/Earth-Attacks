using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private SceneFader _sceneFader;

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        _sceneFader.FadeTo(_levelNumber);
    }

    public void ExitLevelToMenu()
    {
        Time.timeScale = 1f;
        _sceneFader.FadeTo(0);
    }
}
