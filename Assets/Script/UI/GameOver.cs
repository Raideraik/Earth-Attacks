using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private int _levelNumber;

    public void RestartLevel() 
    {
        SceneManager.LoadScene(_levelNumber);
    }

    public void ExitLevelToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
