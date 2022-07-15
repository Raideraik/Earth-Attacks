using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectroUI : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private Button[] _levelButtons;


    private void Start()
    {
        InitializeLevels();

    }

    public void ResetLevels()
    {
        PlayerPrefs.SetInt("levelReached", 0);
        InitializeLevels();
    }

    private void InitializeLevels() 
    {
        int levelReached = PlayerPrefs.GetInt("levelReached");

        for (int i = 1; i < _levelButtons.Length; i++)
        {
            if (i  > levelReached)
                _levelButtons[i].interactable = false;
        }
    }

    public void SelectLevel(int number)
    {
        _sceneFader.FadeTo(number);
    }

}
