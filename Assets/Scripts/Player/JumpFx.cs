using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class JumpFx : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        if(TryGetComponent<Animator>(out var animator))
        {
            _animator = animator;
        }
    }

    private async void OnEnable()
    {
        _animator.Play("jumpFx");
        var task = Task.Delay(500);

        while (!task.IsCompleted)
        {
            await Task.Yield();
        }
        
        _animator.Rebind();
        gameObject.SetActive(false);
    }
    
    
}
