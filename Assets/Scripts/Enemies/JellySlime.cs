using UnityEngine;
public class JellySlime : SomethingHarmful, IResetable
{
    private const string JumpAnimationState = "JellyJump";
    private Animator _animator;
    private Vector3 _startPosition;
    private void Awake()
    {
        if (TryGetComponent<Animator>(out var animator))
        {
            _animator = animator;
        }
        _startPosition = transform.localPosition;
    }

    private void OnEnable()
    { 
        _animator.Play(JumpAnimationState);
    }

    public void Reset()
    {
        gameObject.SetActive(true);
        transform.localPosition = _startPosition;
        _animator.Play(JumpAnimationState);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            DealDamage(playerHealth);
            Disable();
        }
    }
}
