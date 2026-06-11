using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool _pool;
    [SerializeField] private Vector2 _direction = new Vector2(0,-1);
    [SerializeField] private List<Transform> _spawnPoints;

    private float _spawnDelaySeconds = 2f;
    private bool _isWork = true;
    private WaitForSeconds _spawnDelay;

    public void Start()
    {
        _spawnDelay = new WaitForSeconds(_spawnDelaySeconds);
        StartCoroutine(EnemySpawnWithDelay());
    }

    private IEnumerator EnemySpawnWithDelay()
    {
        while (_isWork)
        {
            int randomSpawnPoint = Random.Range(0, _spawnPoints.Count);

            Enemy enemy = _pool.Get();
            enemy.LifeTimeEnded += OnLifeTimeEnded;

            enemy.transform.position = _spawnPoints[randomSpawnPoint].position;

            enemy.SetDirectionForMove(_direction);

            yield return _spawnDelay;
        }
    }

    private void OnLifeTimeEnded(Enemy enemy)
    {
        enemy.LifeTimeEnded -= OnLifeTimeEnded;
        _pool.Release(enemy);
    }
}