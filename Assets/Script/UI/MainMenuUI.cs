using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;

    public void NewGame() 
    {
       _sceneFader.FadeTo(1);
    }

    public void ChooseLevel(int _levelNumber) 
    {
        _sceneFader.FadeTo(_levelNumber);
    }



    public void ExitGame()
    {
        Application.Quit();
    }
}
