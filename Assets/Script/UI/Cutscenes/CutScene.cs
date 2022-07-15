using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _speech;
    [SerializeField] private ImageText[] _slides;
    [SerializeField] private SceneFader _sceneFader;
    private int _sliderIndex = 0;

    public void ChangePage()
    {
            if (_sliderIndex == _slides[_sliderIndex].SpriteNumber)
                _sliderIndex++ ;


        if (_sliderIndex != _slides.Length)
        {

            _image.sprite = _slides[_sliderIndex].Sprite;
            _speech.text = _slides[_sliderIndex].Text;
        }
        
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
