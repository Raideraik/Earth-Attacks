using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;

    public void RestartLevel(int restartLevelNumber)
    {
        Time.timeScale = 1f;
        _sceneFader.FadeTo(restartLevelNumber);
    }

    public void ExitLevelToMenu()
    {
        Time.timeScale = 1f;
        _sceneFader.FadeTo(0);
    }

    public void NextLevel(int nextLevelNumber) 
    {
        Time.timeScale = 1f;
        _sceneFader.FadeTo(nextLevelNumber);
    }
}
