using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneFader : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _colorOfFade;
    [SerializeField] private AnimationCurve _fadeCurve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float time = 1f;
        float curve;

        while (time > 0f)
        {
            time -= Time.deltaTime;
            curve = _fadeCurve.Evaluate(time);
            _image.color = new Color(_colorOfFade.r, _colorOfFade.g, _colorOfFade.b, curve);
            yield return 0;
        }
    }
    private IEnumerator FadeOut(int scene)
    {
        float time = 0f;
        float curve;

        while (time < 1f)
        {
            time += Time.deltaTime;
            curve = _fadeCurve.Evaluate(time);
            _image.color = new Color(_colorOfFade.r, _colorOfFade.g, _colorOfFade.b, curve);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }

    public void FadeTo(int scene) 
    {
        StartCoroutine(FadeOut(scene));
    }
}
