using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float speedDelta = 7f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float spawnDelay = 1f;
    [SerializeField] private float spawnDelayDelta = 2f;
    [SerializeField] private GameObject ememyPrefab;
    [SerializeField] private RectTransform targetTransform;
    [SerializeField] Transform spawnPoint;

    private GameObject enemy;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy() {

        while (true) {
            enemy = Instantiate(ememyPrefab, spawnPoint.position, Quaternion.identity);

            enemy.GetComponent<EnemyMover>().SetTargetPosition(targetTransform, moveSpeed, speedDelta);
            yield return new WaitForSeconds(Random.Range(spawnDelay, spawnDelayDelta));
        }

    }
}
