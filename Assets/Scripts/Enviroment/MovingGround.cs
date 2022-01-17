using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    private const float MaxBackPositionMultiplier = 1.5f;
    private const float GapSize = 0f;
    [SerializeField] private float movingSpeed;
    [SerializeField] private float firstPlatformXPos = -30.01f;
    [SerializeField] private GameObject[] platformPrefabs;

    private List<RectTransform> _platforms;
    private List<RectTransform> _otherObjects;

    private float _backPlatformPositionX;

    // Update is called once per frame
    private void Awake()
    {
        //Init platformsPool
        _platforms = new List<RectTransform>(platformPrefabs.Length);
        for (int i = 0; i < platformPrefabs.Length; i++)
        {
            var platform = Instantiate(platformPrefabs[i], transform, false);
            if (i != 0)
            {
                var newLastPlatformPosition = _platforms[i - 1].localPosition;
                newLastPlatformPosition.x += _platforms[i - 1].rect.width + GapSize;
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

    private void Update()
    {
        MoveGround();
        if (_backPlatformPositionX < firstPlatformXPos * MaxBackPositionMultiplier)
        {
            MoveLastPlatformAhead();
            _backPlatformPositionX = int.MaxValue;
        }
    }

    public void MoveGround()
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
        newLastPlatformPosition.x += _platforms[highestPlatformIndex].rect.width + GapSize;
        _platforms[lowestPlatformIndex].localPosition = newLastPlatformPosition;
    }

    private void CheckPosition(Transform prefabPosition)
    {
/*        if (prefabPosition.position.x < -22)
        {
            var position = new Vector3(prefabPosition.position.x, prefabPosition.position.y, prefabPosition.position.z);
            position.x = 22;
            prefabPosition.position = position;
        }*/
    }
}