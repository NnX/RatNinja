using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public int damage = 20;
    
    private float _moveSpeed = 1f;
    private RectTransform _targetTransform;
    private Vector2 _position;
    private Vector2 _transformPosition;

    void Update()
    {
        if(_targetTransform != null)
        {
            var position = transform.position;
            position = Vector3.MoveTowards(
                            position,
                            new Vector3(_targetTransform.position.x, position.y, 1f),
                            _moveSpeed * Time.deltaTime);
            transform.position = position;
        }
    }

    public void SetTargetPosition(RectTransform targetTransform, float moveSpeed, float deltaSpeed)
    {
        _moveSpeed = Random.Range(moveSpeed, moveSpeed + deltaSpeed);
        _targetTransform = targetTransform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            playerHealth.ApplyDamage(damage);
            Destroy(gameObject);
        }
    }
}