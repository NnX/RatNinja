using UnityEngine;
using Random = UnityEngine.Random;

public class Rat : SomethingHarmful, IResetable
{
    private float _moveSpeed = 1f;
    private RectTransform _targetTransform;
    private Vector2 _position;
    private Vector2 _transformPosition;
    private Vector3 _target;
    private Vector3 _startPosition;
    private float _defaultSpeed;

    private void Awake()
    {
        _startPosition = transform.position;
        damage = 20;
    }

    private void Update()
    {
        if(_targetTransform != null)
        {
            var current = transform.position;
            _target.x = _targetTransform.position.x;
            _target.y = current.y;
            _target.z = 1f;
            
            current = Vector3.MoveTowards(current, _target,_moveSpeed * Time.deltaTime);
            transform.position = current;

            if (current.x <= _target.x && gameObject.activeSelf)
            {
                Disable();
            }
        }
    }

    public void SetTargetPosition(RectTransform targetTransform, float moveSpeed, float deltaSpeed)
    {
        Reset();
        _defaultSpeed = Random.Range(moveSpeed, moveSpeed + deltaSpeed);
        _moveSpeed = _defaultSpeed;
        _targetTransform = targetTransform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            DealDamage(playerHealth);
            Disable();
        }
    }

    public void Reset()
    {
        transform.position = _startPosition;
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void IncreaseSpeed()
    {
        _moveSpeed = _defaultSpeed * 2;
    }

    public void ResetSpeed()
    {
        _moveSpeed = _defaultSpeed;
    }
    
}