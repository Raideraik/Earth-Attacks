using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    private Slider _healthSlider;

    private void Start()
    {
        _healthSlider = GetComponentInChildren<Slider>();
        _healthSlider.maxValue = _enemy.Health;
        _healthSlider.value = _healthSlider.maxValue;
    }

    private void OnEnable()
    {
        _enemy.HealthChanged += OnHealthChanged;
        _enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= OnHealthChanged;
        _enemy.Died -= OnDied;
    }

    private void OnHealthChanged(float health)
    {
        _healthSlider.value = health;
    }

    private void OnDied()
    {
        _healthSlider.value = _healthSlider.maxValue;
    }
}
