using System;
using UnityEngine;
using UnityEngine.UI;

public class MovingGround : MonoBehaviour
{
    [SerializeField] Transform[] platforms;
    [SerializeField] float movingSpeed; 

    // Update is called once per frame
    void Update()
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
    }

    private void CheckPositon(Transform prefabPosition)
    {
/*        if (prefabPosition.position.x < -22)
        {
            var position = new Vector3(prefabPosition.position.x, prefabPosition.position.y, prefabPosition.position.z);
            position.x = 22;
            prefabPosition.position = position;
        }*/
    }
}
