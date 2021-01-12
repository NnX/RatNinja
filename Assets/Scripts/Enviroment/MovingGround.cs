using System;
using UnityEngine;
using UnityEngine.UI;

public class MovingGround : MonoBehaviour
{
    [SerializeField] Transform firstGroundTransform; 
    [SerializeField] Transform secondGroundTransform; 
    [SerializeField] float movingSpeed; 

    // Update is called once per frame
    void Update()
    {
        CheckPositon(firstGroundTransform);
        CheckPositon(secondGroundTransform);
        MoveGround();

    }

    private void MoveGround()
    {
        var ground1Position = new Vector3(firstGroundTransform.position.x, firstGroundTransform.position.y, firstGroundTransform.position.z);
        //Debug.Log($"[test] ground1Position= {ground1Position}");
        var ground2Position = new Vector3(secondGroundTransform.position.x, secondGroundTransform.position.y, secondGroundTransform.position.z);

        ground1Position.x -= movingSpeed * Time.deltaTime;
        ground2Position.x -= movingSpeed * Time.deltaTime;

        firstGroundTransform.position = ground1Position;
        secondGroundTransform.position = ground2Position;
    }

    private void CheckPositon(Transform prefabPosition)
    {
        if (prefabPosition.position.x < -22)
        {
            var position = new Vector3(prefabPosition.position.x, prefabPosition.position.y, prefabPosition.position.z);
            position.x = 22;
            prefabPosition.position = position;
        }
    }
}
