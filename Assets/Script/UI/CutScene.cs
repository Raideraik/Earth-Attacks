using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _slides;
    [SerializeField] private SceneFader _sceneFader;
    private int _sliderIndex = 0;


    private void Update()
    {
        for (int i = 0; i < _slides.Length; i++)
        {
            if (_image.sprite == _slides[i])
                _sliderIndex = i + 1;

        }
    }

    public void ChangePage()
    {
        if (_sliderIndex != _slides.Length)
            _image.sprite = _slides[_sliderIndex];

    }

    public void NextLevel(int nextLevelNumber)
    {
        if (_sliderIndex == _slides.Length)
        {
            Time.timeScale = 1f;
            _sceneFader.FadeTo(nextLevelNumber);
        }
    }
}
