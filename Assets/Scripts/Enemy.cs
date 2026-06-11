using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    private EnemyMover _enemyMover;
    private float _lifeTimeSeconds = 2f;
    private WaitForSeconds _lifeTime;

    public Action<Enemy> LifeTimeEnded;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _lifeTime = new WaitForSeconds(_lifeTimeSeconds);
    }

    public void SetDirectionForMove(Vector2 direction) 
    {
        _enemyMover.StartMove(direction);

        StartCoroutine(ReturnAfterTime());
    }

    private IEnumerator ReturnAfterTime() 
    {
        yield return _lifeTime;

        LifeTimeEnded?.Invoke(this);
    }
}