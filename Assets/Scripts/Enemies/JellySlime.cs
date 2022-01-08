using UnityEngine;
public class JellySlime : MonoBehaviour
{
    private const string JumpAnimation = "JellyJump";
    private void OnEnable()
    {
        if (TryGetComponent<Animator>(out var animator))
        {
            animator.Play(JumpAnimation);
        }
    }
}
