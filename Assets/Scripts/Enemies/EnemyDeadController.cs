using System.Collections;
using System.Collections.Generic;
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
    }
}
