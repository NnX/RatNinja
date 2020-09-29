using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadController : MonoBehaviour
{
    [SerializeField] Animator animator;
    public void PlayDeath() {
        animator.Play("RatDeadLeftToRight");
    }
}
