using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _value;
    [SerializeField] private GameObject _deathEffect;

    private int _startHealth;

    private void Awake()
    {
        _startHealth = _health;
    }

    private void OnDisable()
    {
        _health = _startHealth;
    }


    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
            Die();

    }

    private void Die()
    {
        GameObject effect = (GameObject)Instantiate(_deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);


        gameObject.SetActive(false);
        PlayerStats.Money += _value;
    }
}
