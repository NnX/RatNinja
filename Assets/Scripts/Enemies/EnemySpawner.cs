using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
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

            enemy.GetComponent<EnemyMover>().SetTargetPosition(targetTransform);
            yield return new WaitForSeconds(Random.Range(2.5f, 4f));
        }

    }
}
