using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Enemy _enemy;
    private Transform _target;
    private int _wavePointIndex = 0;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _target = WayPoints.Points[0];
    }

    private void OnEnable()
    {
        _wavePointIndex = 0;
        _target = WayPoints.Points[_wavePointIndex];
    }

    private void Update()
    {
        
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _enemy.Speed * Time.deltaTime, Space.World);

        

        if (Vector3.Distance(transform.position, _target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        _enemy.ReturnSpeed();
    }

    private void GetNextWayPoint() 
    {

        
        if (_wavePointIndex >= WayPoints.Points.Length-1)
        {
            EndPath();
            return;
        }

        _wavePointIndex++;
        _target = WayPoints.Points[_wavePointIndex];
       
    }

    private void EndPath() 
    {
        PlayerStats.Lives--;

        gameObject.SetActive(false);
        _wavePointIndex = 0;
        _target = WayPoints.Points[_wavePointIndex];
    }
}
