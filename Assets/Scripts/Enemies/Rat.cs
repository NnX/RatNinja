using GameEnvironment.Controllers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class Rat : SomethingHarmful, IResetable
    {
        private float _moveSpeed = 1f;
        private Vector2 _position;
        private Vector2 _transformPosition;
        private Vector3 _target;
        private Vector3 _startPosition;
        private Vector3 _movement;
        private float _defaultSpeed;

        private void Awake()
        {
            /*var ratTransform = transform;
            _startPosition = ratTransform.position;
            _targetTransform = (RectTransform)ratTransform;*/
            _movement = new Vector3(-1, 0, 0);
            damage = 20;
            // TODO move rat without target transform
        }

        private void Update()
        {
            transform.Translate(_movement * _moveSpeed * Time.deltaTime);
        }

        public void SetTargetPosition(float moveSpeed, float deltaSpeed)
        {
            Reset();
            _defaultSpeed = Random.Range(moveSpeed, moveSpeed + deltaSpeed);
            _moveSpeed = _defaultSpeed;
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
}