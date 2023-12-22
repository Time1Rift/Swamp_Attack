using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private List<Wave> _waves = new();

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;

    public event Action AllEnemySpawned;
    public event Action<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            _timeAfterLastSpawn = 0;
            InstantiateEnemy();
            _spawned++;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.CountEnemies);
        }

        if (_spawned == _currentWave.CountEnemies)
        {
            _currentWaveNumber++;
            _spawned = 0;

            if (_currentWaveNumber < _waves.Count)
                AllEnemySpawned?.Invoke();

            _currentWave = null;
        }
    }

    public void NextWave() => SetWave(_currentWaveNumber);

    private void InstantiateEnemy()
    {
        Enemy newEnemy = Instantiate(_currentWave.Enemy, _spawnPosition.position, Quaternion.identity);
        newEnemy.Init(_player);
        newEnemy.Died += OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        _player.AddMoney(enemy.Reward);
    }

    private void SetWave(int index) => _currentWave = _waves[index];
}

[Serializable]
public class Wave
{
    public Enemy Enemy;
    public int CountEnemies;
    public float Delay;
}