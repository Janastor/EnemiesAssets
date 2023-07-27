using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    private static Random _random = new Random();
    private EnemySpawnPoint[] _spawnPoints = new EnemySpawnPoint[] { };
    private int _minRandom = 0;
    private int _maxRandom;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<EnemySpawnPoint>();
        _maxRandom = _spawnPoints.Length;
        SpawnInRandomSpawner();
    }

    private void SpawnInRandomSpawner()
    {
        _spawnPoints[_random.Next(_minRandom, _maxRandom)].Spawn();
        StartCoroutine(SpawnTimer());
    }

    private IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(_spawnDelay);
        SpawnInRandomSpawner();
    }
}
