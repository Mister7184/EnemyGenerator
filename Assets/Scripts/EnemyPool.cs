using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private List<Enemy> _freeEnemiesList = new List<Enemy>();
    private int _enemiesMaxCount = 10;

    private void Awake()
    {
        for (int i = 0; i < _enemiesMaxCount; i++)
        {
            Create();
        }
    }

    private void Create() 
    {
        Enemy enemy = Instantiate(_enemyPrefab);

        enemy.gameObject.SetActive(false);

        _freeEnemiesList.Add(enemy);
    }

    public Enemy Get()
    {
        if(_freeEnemiesList.Count == 0)
            Create();

        Enemy enemy = _freeEnemiesList[0];
        _freeEnemiesList.RemoveAt(0);

        enemy.gameObject.SetActive(true);

        return enemy;
    }
    
    public void Release(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);

        _freeEnemiesList.Add(enemy);
    }
}