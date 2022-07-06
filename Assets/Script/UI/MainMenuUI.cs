using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    public void NewGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void ChooseLevel(int _levelNumber) 
    {
        SceneManager.LoadScene(_levelNumber);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
