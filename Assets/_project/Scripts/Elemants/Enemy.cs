using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed;

    private Rigidbody _rb;
    private NavMeshAgent _agent;
    private Player _player;
    private Transform _transform;

    public int startHealth;
    private int _curHealth;

    private HealthBar _healthBar;

    public EnemyState enemyState;

    public float enemySightRange;

    private void Start()
    {
        _transform = transform;
        _curHealth = startHealth;
        _agent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        _player = GameDirector.instance.player;
        _healthBar = GetComponentInChildren<HealthBar>();
        _healthBar.SetHealthRatio(1);
    }

    private void Update()
    {
        var distanceVector = _player.transform.position - _transform.position;
        var distance = distanceVector.magnitude;
        if (distance < enemySightRange && enemyState != EnemyState.Moving)
        {
            if (Physics.Raycast(_transform.position + Vector3.up, distanceVector.normalized, out var hit, distance)
                && hit.transform.CompareTag("Player"))
            {
                enemyState = EnemyState.Moving;
            }
        }

        if (enemyState == EnemyState.Moving)
        {
            _agent.SetDestination(_player.transform.position);
        }
    }

    public void GetHit(int damage)
    {
        _curHealth -= damage;
        _healthBar.SetHealthRatio((float)_curHealth / startHealth);
        if (_curHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}

public enum EnemyState
{
    Idle,
    Moving,
    Attacking,
    Dead,
}