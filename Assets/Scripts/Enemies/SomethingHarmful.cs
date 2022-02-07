using UnityEngine;

namespace Enemies
{
    public abstract class SomethingHarmful : MonoBehaviour
    {
        public int damage = 10;
        protected void DealDamage(PlayerHealth playerHealth)
        {
            playerHealth.ApplyDamage(damage);
        }
    
    }
}
