using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _impactEffect;
    [SerializeField] private float _speed = 70f;
    [SerializeField] private float _explosionRadius = 0f;
    [SerializeField] private float _timeOfEffects;
    [SerializeField] public int _damage;

    private Transform _target;

    public void Seek(Transform target) 
    {
        _target = target;
    }

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = _target.position - transform.position;
        float distanceThisFrame = _speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(_target);
    }

    private void HitTarget() 
    {
        GameObject effectIns = (GameObject)Instantiate(_impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, _timeOfEffects);

        if (_explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            if (_target.TryGetComponent(out Enemy enemy))
            {
            Damage(enemy, _damage);
            }
        }

        

        Destroy(gameObject);
    }

    private void Explode() 
    {
        Collider[] colliders =  Physics.OverlapSphere(transform.position, _explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                Damage(enemy,_damage);
            }
        }
    }


    private void Damage(Enemy enemy, int damage) 
    {
        enemy.TakeDamage(damage);
       // enemy.gameObject.SetActive(false);
        //Destroy(enemy);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }

}
