using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool _pool;
    [SerializeField] private Transform _targetEnemy;
    [SerializeField] private List<Transform> _spawnPoints;

    private float _spawnDelaySeconds = 2f;
    private bool _isWork = true;

    public void Start()
    {
        StartCoroutine(EnemySpawnWithDelay());
    }

    private IEnumerator EnemySpawnWithDelay()
    {
        while (_isWork)
        {
            List<Transform> availablePoints = new List<Transform>(_spawnPoints);

            int randomSpawnPoint = Random.Range(0, availablePoints.Count);

            Enemy enemy = _pool.Get();

            enemy.TouchedTarget += OnTouchedTarget;

            enemy.transform.position = availablePoints[randomSpawnPoint].position;

            enemy.SetTarget(_targetEnemy);

            availablePoints.RemoveAt(randomSpawnPoint);

            yield return new WaitForSeconds(_spawnDelaySeconds);
        }
    }

    private void OnTouchedTarget(Enemy enemy) 
    {
        _pool.Release(enemy);

        enemy.TouchedTarget -= OnTouchedTarget;
    }
}