using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int _turnSpeed;
    [SerializeField] private bool _isFlying = false;
    public bool IsFlying => _isFlying;

    private Enemy _enemy;
    private Transform _target;
    private int _wavePointIndex = 0;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        if (_isFlying)
        {
            _target = FlyingWayPoints.FlyingPoints[0];
        }
        else
        {
            _target = WayPoints.Points[0];
        }
    }

    private void OnEnable()
    {
        _wavePointIndex = 0;
        if (_isFlying)
        {
            _target = FlyingWayPoints.FlyingPoints[_wavePointIndex];
        }
        else
        {
            _target = WayPoints.Points[_wavePointIndex];
        }
    }

    private void Update()
    {

        Vector3 direction = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * _turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        transform.Translate(direction.normalized * _enemy.Speed * Time.deltaTime, Space.World);


        if (Vector3.Distance(transform.position, _target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        _enemy.ReturnSpeed();
    }

    private void GetNextWayPoint()
    {


        if (_wavePointIndex >= WayPoints.Points.Length - 1)
        {
            EndPath();
            return;
        }
        else if (_isFlying && _wavePointIndex >= FlyingWayPoints.FlyingPoints.Length - 1)
        {
            EndPath();
            return;
        }

        _wavePointIndex++;
        if (_isFlying)
        {
            _target = FlyingWayPoints.FlyingPoints[_wavePointIndex];
        }
        else
        {
            _target = WayPoints.Points[_wavePointIndex];
        }
        //_target = WayPoints.Points[_wavePointIndex];

    }

    private void EndPath()
    {
        PlayerStats.Lives--;
        Spawner._enemyAlive--;

        gameObject.SetActive(false);
        _wavePointIndex = 0;
        if (_isFlying)
        {
            _target = FlyingWayPoints.FlyingPoints[_wavePointIndex];
        }
        else
        {
            _target = WayPoints.Points[_wavePointIndex];
        }
        //_target = WayPoints.Points[_wavePointIndex];
    }
}
