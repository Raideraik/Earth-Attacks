using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _speed;
    [SerializeField] private int _value;
    [SerializeField] private GameObject _deathEffect;

    public float Speed => _speed;

    private float _startHealth;
    private float _startSpeed;

    private void Awake()
    {
        _startHealth = _health;
        _startSpeed = _speed;
    }

    private void OnDisable()
    {
        _health = _startHealth;
        _speed = _startSpeed;
    }

    private void Die()
    {
        GameObject effect = (GameObject)Instantiate(_deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);


        gameObject.SetActive(false);
        PlayerStats.Money += _value;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
            Die();

    }

    public void ReturnSpeed() 
    {
        _speed = _startSpeed;

    }

    public void Slow(float amount) 
    {
        _speed = _startSpeed*(1f - amount);
    }

}
