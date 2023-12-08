using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", _spawnInterval, _spawnInterval);
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, _spawnPoints.Length);
        Transform spawnPoint = _spawnPoints[spawnIndex];

        GameObject enemy = Instantiate(_enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemy.transform.forward = spawnPoint.forward;
    }
}