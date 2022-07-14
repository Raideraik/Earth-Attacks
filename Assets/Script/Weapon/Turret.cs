using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class Turret : MonoBehaviour
{

    [Header("General")]
    [SerializeField] private GameObject _bulletTemplate;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Transform _partToRotate;
    [SerializeField] private string _enemyTag = "Enemy";
    [SerializeField] private float _range = 15f;


    [Header("Use Bullets")]
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _fireRate = 1f;
    private float _maxFireRate;
    private bool _poweredUp = false;
    public bool PowerUp => _poweredUp;


    [Header("Use Laser")]
    [SerializeField] private bool _useLaser = false;
    [SerializeField] private int _damageOverTime;
    [SerializeField] private float _slowRate = 0.5f;
    [SerializeField] private float _impactOffset;
    [SerializeField] private Light _impactLight;
    private ParticleSystem _impactEffect;
    private LineRenderer _lineRenderer;

    [Header("Block")]
    [SerializeField] private bool _useBlock = false;
    [SerializeField] private float _charges = 100;
    [SerializeField] private float _chargeSpeed = 10;
    private float _maxCharges;

    [Header("Melee Attack")]
    [SerializeField] private bool _useMelee = false;
    [SerializeField] private float _meleeDamage;

    [Header("Power UP")]
    [SerializeField] private bool _usePoweUP = false;
    [SerializeField] private float _fireUpRate = 20;


    [Header("Flying")]
    [SerializeField] private bool _useFlying = false;
    [SerializeField] private string _flyingEnemyTag = "FlyingEnemy";

    private AudioSource _audio;

    private float _fireCountdown = 0f;
    private Transform _target;
    private Enemy _enemy;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        if (_useLaser)
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _impactEffect = GetComponentInChildren<ParticleSystem>();
        }
        _maxFireRate = _fireRate;

    }

    private void ReturnFireRate() 
    {
        _poweredUp = false;
        _fireRate = _maxFireRate;
    }

    public void SetFireRate(float fireRateUp) 
    {
        _poweredUp = true;
        _fireRate *= fireRateUp;
    }

    private void UpdateTarget()
    {
        if (_useFlying)
        {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_flyingEnemyTag);
            Targeting(enemies);
        }
        else
        {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemyTag);
            Targeting(enemies);
        }
        

    }

    private void Targeting(GameObject[] enemies) 
    {
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
            _enemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            _target = null;
        }
    }


    private void Update()
    {
        if (_target == null)
        {
            if (_useLaser)
                if (_lineRenderer.enabled)
                {

                    _lineRenderer.enabled = false;
                    _impactEffect.Stop();
                    _impactLight.enabled = false;
                }

            return;
        }
        LockOnTarget();


        if (_useLaser)
        {
            Laser();
        }
        else if (_useBlock)
        {
            Block();
        }
        else if (_usePoweUP)
        {
            PowerUP();
        }
        else if (_useMelee)
        {
            
            if (_fireCountdown <= 0f)
            {
                MeleeAttack();
                _fireCountdown = 1f / _fireRate;
            }
            _fireCountdown -= Time.deltaTime;
        }
        else
        {
            if (_fireCountdown <= 0f)
            {
                Shoot();
                _fireCountdown = 1f / _fireRate;
               ReturnFireRate();
            }
            _fireCountdown -= Time.deltaTime;
        }

    }

    private void LockOnTarget()
    {
        Vector3 direction = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(_partToRotate.rotation, lookRotation, Time.deltaTime * _turnSpeed).eulerAngles;
        _partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Shoot()
    {
        _audio.Play();

        GameObject bulletGO = (GameObject)Instantiate(_bulletTemplate, _firePoint.position, _firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(_target);
    }

    private void Laser()
    {
        _enemy.TakeDamage(_damageOverTime * Time.deltaTime);
        _enemy.Slow(_slowRate);

        if (!_lineRenderer.enabled)
        {
            _lineRenderer.enabled = true;
            _impactEffect.Play();
            _impactLight.enabled = true;
        }

        _lineRenderer.SetPosition(0, _firePoint.position);
        _lineRenderer.SetPosition(1, _target.position);

        Vector3 direction = _firePoint.position - _target.position;

        _impactEffect.transform.position = _target.position + direction.normalized * _impactOffset;

        _impactEffect.transform.rotation = Quaternion.LookRotation(direction);
    }
    private void Block()
    {
        if (_target != null && _charges > 0)
        {
            _enemy.Slow(1);
            _charges -= Time.deltaTime * _chargeSpeed;
        }
        else if (_charges <= 0)
        {
            //Выводить что разряжена
            _charges += Time.deltaTime * _chargeSpeed;
        }
    }

    private void PowerUP() 
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _range);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Turret turret))
            {
                if (!turret._poweredUp)
                {
                turret.SetFireRate(_fireUpRate);
                }
            }
        }
    } 

    private void MeleeAttack()
    {
        _enemy.TakeDamage(_meleeDamage);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
