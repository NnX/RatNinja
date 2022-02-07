using System.Linq;
using UnityEngine;

namespace Environment
{
    public class MovingBackground : MonoBehaviour
    {
        [SerializeField] private float backgroundWidth;
        [SerializeField] private float movingSpeed;
        [SerializeField] private Transform[] backgrounds;
        private Vector3 _bgPosition;

        private void Update()
        {
            MoveGround();
        }

        private void MoveGround()
        {
            foreach (var background in backgrounds)
            {
                var position = background.position;
                var ground1Position = new Vector3(position.x, position.y, position.z);
                ground1Position.x -= movingSpeed * Time.deltaTime;
                position = ground1Position;
                background.position = position;
                if (background.position.x < -(backgroundWidth + 5))
                {
                    var maxPositionX = backgrounds.Max(x => x.position.x);
                    _bgPosition.x = maxPositionX + backgroundWidth;
                    _bgPosition.y = background.position.y;
                    _bgPosition.z = background.position.z;
                    background.position = _bgPosition;
                }
            } 
        }
    }
}
