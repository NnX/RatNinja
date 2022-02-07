using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class MovingGround : MonoBehaviour
    {
        private const int SlideSpeedAcceleration = 3;
        private const int GapIncreaseDelta = 5;
        private const float MaxBackPositionMultiplier = 1.5f;

        [SerializeField] private float movingSpeed;
        [SerializeField] private float firstPlatformXPos = -30.01f;
        [SerializeField] private GameObject[] platformPrefabs;

        private List<RectTransform> _platforms;
        private float _backPlatformPositionX;
        private float _defaultSpeed;
        private float _gapSize = 0f;

        private void Awake()
        {
            _defaultSpeed = movingSpeed; 
            //Init platformsPooldd
            _platforms = new List<RectTransform>(platformPrefabs.Length);
            for (int i = 0; i < platformPrefabs.Length; i++)
            {
                var platform = Instantiate(platformPrefabs[i], transform, false);
                if (i != 0)
                {
                    var newLastPlatformPosition = _platforms[i - 1].localPosition;
                    newLastPlatformPosition.x += _platforms[i - 1].rect.width + _gapSize;
                    platform.transform.localPosition = newLastPlatformPosition;
                }
                else
                {
                    var firstPlatformPosition = platform.transform.localPosition;
                    firstPlatformPosition.x = firstPlatformXPos;
                    platform.transform.localPosition = firstPlatformPosition;
                }

                _platforms.Add((RectTransform)platform.transform);
            }
        }

        public void SetMoveSpeed()
        {
            movingSpeed = _defaultSpeed * SlideSpeedAcceleration;
        }
        public void ResetSpeed()
        {
            movingSpeed = _defaultSpeed;
        }

        public void ResetGapSize()
        {
            _gapSize = 0;
        }
        
        public void IncreaseGapSize()
        {
            _gapSize += GapIncreaseDelta;
        }

        private void Update()
        {
            MoveGround();
            if (_backPlatformPositionX < firstPlatformXPos * MaxBackPositionMultiplier)
            {
                MoveLastPlatformAhead();
                _backPlatformPositionX = int.MaxValue;
            }
        }

        private void MoveGround()
        {
            foreach (var platform in _platforms)
            {
                var position = platform.position;
                var ground1Position = new Vector3(position.x, position.y, position.z);
                ground1Position.x -= movingSpeed * Time.deltaTime;
                position = ground1Position;
                platform.position = position;
            
                if (position.x < _backPlatformPositionX)
                {
                    _backPlatformPositionX = position.x;
                }
            }
        }

        private void MoveLastPlatformAhead()
        {
            var lowestPosition = float.MaxValue;
            var highestPosition = float.MinValue;
            var lowestPlatformIndex = 0;
            var highestPlatformIndex = 0;
            var index = 0;
            foreach (var rectTransform in _platforms)
            {
                if (rectTransform.localPosition.x < lowestPosition)
                {
                    lowestPosition = rectTransform.localPosition.x;
                    lowestPlatformIndex = index;
                }

                if (rectTransform.localPosition.x > highestPosition)
                {
                    highestPosition = rectTransform.localPosition.x;
                    highestPlatformIndex = index;
                }

                index++;
            }

            var newLastPlatformPosition = _platforms[highestPlatformIndex].localPosition;
            newLastPlatformPosition.x += _platforms[highestPlatformIndex].rect.width + _gapSize;
            _platforms[lowestPlatformIndex].localPosition = newLastPlatformPosition;

            if (_platforms[highestPlatformIndex].TryGetComponent<Platform>(out var platform))
            {
                platform.ResetState();
            }
        }
    }
}