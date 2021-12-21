using System.Collections;
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

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    // TODO implement enemy pool
    // TODO spawn enemies from update method
    private IEnumerator SpawnEnemy() {

        while (true) {
            _enemy = Instantiate(ememyPrefab, spawnPoint.position, Quaternion.identity);
            _enemy.GetComponent<EnemyMover>().SetTargetPosition(targetTransform, moveSpeed, speedDelta);
            yield return new WaitForSeconds(Random.Range(SpawnDelay, SpawnDelayDelta));
        }

    }
}
