using System.Collections;
using UnityEngine;

public class EnemyDeadController : MonoBehaviour
{
    [SerializeField] Animator animator;
    
    public void PlayDeath(float scaleX) {
        if(scaleX > 0) {
            animator.Play("RatDeadLeftToRight");

        } else {
            animator.Play("RatDeadRightToLeft");
        }

        StartCoroutine(ClearDeadBody());
    }

    private IEnumerator ClearDeadBody()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
