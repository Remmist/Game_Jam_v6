using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab1;
    [SerializeField] private GameObject enemyPrefab2;
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
            var rand = new System.Random();
            if (rand.Next(0, 1) == 1)
            {
                Instantiate(enemyPrefab2, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(enemyPrefab1, transform.position, Quaternion.identity);
            }
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
