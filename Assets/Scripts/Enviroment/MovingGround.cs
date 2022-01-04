using UnityEngine;

public class MovingGround : MonoBehaviour
{
    private const float TimeToUpdate = 5f;
    private const float GapSize = 5f;
    [SerializeField] private RectTransform spawnPoint;
    [SerializeField] private float movingSpeed;
    [SerializeField] private RectTransform[] platforms;
    [SerializeField] private GameObject[] platformPrefabs;

    private float _timer;
    
    // Update is called once per frame
    private void Start()
    {
        //Init platformsPool
        
    }

    private void Update()
    { 
        MoveGround();
    }

    private void MoveGround()
    {
        foreach(var platform in platforms)
        {
            var ground1Position = new Vector3(platform.position.x, platform.position.y, platform.position.z);
            ground1Position.x -= movingSpeed * Time.deltaTime;
            platform.position = ground1Position;
        }

        if (_timer > TimeToUpdate)
        {
            _timer = 0;
            var lowestPosition = float.MaxValue;
            var highestPosition = float.MinValue;
            var lowestPlatformIndex = 0;
            var highestPlatformIndex = 0;
            var index = 0;
            foreach (var rectTransform in platforms)
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

            var newLastPlatformPosition = platforms[highestPlatformIndex].localPosition;
            newLastPlatformPosition.x += platforms[highestPlatformIndex].rect.width + GapSize;
            platforms[lowestPlatformIndex].localPosition = newLastPlatformPosition;
        }

        _timer += Time.deltaTime;
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
