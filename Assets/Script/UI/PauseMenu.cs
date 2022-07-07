using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameMaster))]
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private SceneFader _sceneFader;
    private GameMaster _gameMaster;

    private void Start()
    {
        _gameMaster = GetComponent<GameMaster>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        _pauseMenu.SetActive(!_pauseMenu.activeSelf);

        if (_pauseMenu.activeSelf)
            Time.timeScale = 0f;
        else if(!_pauseMenu.activeSelf && !_gameMaster.GameEnded)
            Time.timeScale = 1f;

    }

    public void Continue() 
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
