using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject pig;
    [SerializeField] private GameObject cheese;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;

    private EnemyCounter _enemyCounter;

    private float _timeUntilSpawn;

    private void Awake()
    {
        SetTimeUntilSpawn();
        _enemyCounter = FindObjectOfType<EnemyCounter>();
    }
    
    void Update()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        _timeUntilSpawn -= Time.deltaTime;
        
        if (enemies.Length >= _enemyCounter.MaxEnemiesOnLevel)
        {
            return;
        }

        if (_timeUntilSpawn <= 0)
        {
            var rand = new System.Random();
            if (rand.Next(0, 100) < 70)
            {
                Instantiate(pig, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(cheese, transform.position, Quaternion.identity);
            }
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
