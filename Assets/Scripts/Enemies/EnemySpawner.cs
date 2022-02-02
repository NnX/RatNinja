using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private const float SpawnDelay = 1f;
    private const float SpawnDelayDelta = 2f;
    [SerializeField] private float speedDelta = 7f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject ememyPrefab;
    [SerializeField] private RectTransform targetTransform;
    [SerializeField] Transform spawnPoint;

    private GameObject _enemy;
    private Queue<GameObject> _enemyPool;

    private void Start()
    {
        _enemyPool = new Queue<GameObject>();
        StartCoroutine(SpawnEnemy());
    }
    public void IncreaseSpeed()
    {
        foreach (var enemy in _enemyPool)
        {
            if (enemy.TryGetComponent<Rat>(out var rat))
            {
                rat.IncreaseSpeed();
            }
        }
    }
    public void ResetSpeed()
    {
        foreach (var enemy in _enemyPool)
        {
            if (enemy.TryGetComponent<Rat>(out var rat))
            {
                rat.ResetSpeed();
            }
        }
    }
    private IEnumerator SpawnEnemy() {

        while (true) {
            if (_enemyPool.Count == 0 || _enemyPool.Peek().activeInHierarchy)
            {
                var enemy = Instantiate(ememyPrefab, spawnPoint.position, Quaternion.identity);
                enemy.GetComponent<Rat>().SetTargetPosition(targetTransform, moveSpeed, speedDelta);
                _enemyPool.Enqueue(enemy);
            }
            else
            {
                _enemy = _enemyPool.Dequeue();
                _enemy.GetComponent<Rat>().SetTargetPosition(targetTransform, moveSpeed, speedDelta);
                _enemyPool.Enqueue(_enemy);
            }
            
            yield return new WaitForSeconds(Random.Range(SpawnDelay, SpawnDelayDelta));
        }
    }
}
