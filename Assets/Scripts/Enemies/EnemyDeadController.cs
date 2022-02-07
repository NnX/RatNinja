
using UnityEngine;

namespace Enemies
{
    public class EnemyDeadController : MonoBehaviour
    {
        [SerializeField] private GameObject deadBody;
    
        public GameObject DeadbodyPrefab()
        {
            return deadBody;
        }

    }
}
