using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;
    private int _wavePointIndex = 0;

    private void Start()
    {
        _target = WayPoints.Points[0];
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    private void GetNextWayPoint() 
    {

        if (_wavePointIndex >= WayPoints.Points.Length-1)
        {
            gameObject.SetActive(false);
            return;
        }

        _wavePointIndex++;
        _target = WayPoints.Points[_wavePointIndex];
    }
}
