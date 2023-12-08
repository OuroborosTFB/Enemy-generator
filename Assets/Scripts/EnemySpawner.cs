using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;

    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform[] _targetTransforms;
    [SerializeField] private float _spawnInterval = 2f;

    private int InvalidSpawnIndex = -1;

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            foreach (Transform spawnPoint in _spawnPoints)
            {
                SpawnEnemy(spawnPoint);
                yield return new WaitForSeconds(_spawnInterval);
            }
        }
    }

    private void SpawnEnemy(Transform spawnPoint)
    {
        if (EnemyPrefabs.Length == 0)
            return;

        GameObject enemyPrefab = EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)];
        if (enemyPrefab == null)
            return;

        GameObject enemyObject = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        if (enemyObject == null)
            return;

        Enemy enemy = enemyObject.GetComponent<Enemy>();
        if (enemy == null)
        {
            Destroy(enemyObject);
            return;
        }

        int spawnIndex = System.Array.IndexOf(_spawnPoints, spawnPoint);
        if (spawnIndex == InvalidSpawnIndex || spawnIndex >= _targetTransforms.Length)
        {
            Destroy(enemyObject);
            return;
        }

        Transform targetTransform = _targetTransforms[spawnIndex];
        if (targetTransform == null)
        {
            Destroy(enemyObject);
            return;
        }

        enemy.SetTarget(targetTransform.gameObject);
        enemy.SetMoveDirection((targetTransform.position - enemy.transform.position).normalized);
    }
}