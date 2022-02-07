using GameEnvironment.Controllers;
using UnityEngine;

namespace Environment
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private GameObject[] resetableObjects;
    
        public void ResetState()
        {
            foreach (var obj in resetableObjects)
            {
                obj.SetActive(true);
                if (obj.TryGetComponent<IResetable>(out var resetable))
                {
                    resetable.Reset();
                }
            }    
        }

    }
}
