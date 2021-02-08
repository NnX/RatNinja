using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{

    [SerializeField] Transform background;
    [SerializeField] float movingSpeed;

    void Update()
    {
        MoveGround();
    }

    private void MoveGround()
    {
        var ground1Position = new Vector3(background.position.x, background.position.y, background.position.z);
        ground1Position.x -= movingSpeed * Time.deltaTime;
        background.position = ground1Position;
    }
}
