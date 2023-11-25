using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;

    private float _timeUntilSpawn;

    private void Awake()
    {
        SetTimeUntilSpawn();
    }
    
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
