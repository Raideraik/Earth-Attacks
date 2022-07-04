using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject _bulletTemplate;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Transform _partToRotate;
    [SerializeField] private string _enemyTag = "Enemy";
    [SerializeField] private float _range = 15f;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _fireRate = 1f;

    private float _fireCountdown = 0f;
    private Transform _target;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= _range)
        {
            _target = nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }

    }

    private void Update()
    {
        if (_target == null)
            return;

        Vector3 direction = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(_partToRotate.rotation, lookRotation, Time.deltaTime*_turnSpeed).eulerAngles;
        _partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (_fireCountdown <= 0f)
        {
            Shoot();
            _fireCountdown = 1f / _fireRate;
        }
        _fireCountdown -= Time.deltaTime;
    }

    private void Shoot() 
    {
      GameObject bulletGO= (GameObject)Instantiate(_bulletTemplate, _firePoint.position, _firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(_target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
