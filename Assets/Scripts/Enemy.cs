using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    private EnemyMover _enemyMover;

    public Action<Enemy> TouchedTarget;
    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    public void SetTarget(Transform target) 
    {
        _enemyMover.UseMove(target);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Target>(out Target target) == true)
            TouchedTarget?.Invoke(this);
    }
}