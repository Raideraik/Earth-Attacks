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
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < _levelButtons.Length; i++)
        {
            if (i+1 > levelReached)
                _levelButtons[i].interactable = false;
        }
    }
    public void SelectLevel(int number)
    {
        _sceneFader.FadeTo(number);
    }

}
