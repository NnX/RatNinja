using DG.Tweening;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeadController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Image deadbodyImage;
    
    public void PlayDeath(float scaleX) {

        //PlayDeathAnimationAsync();
        /*        if(scaleX > 0) {
                    animator.Play("RatDeadLeftToRight");

                } else {
                    animator.Play("RatDeadRightToLeft");
                }

                StartCoroutine(ClearDeadBody());*/
    }

    private IEnumerator ClearDeadBody()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    public async void PlayDeathAnimationAsync()
    {
       await Task.Run(() => transform.DOMove(new Vector2(1, 1), 2f));
        Destroy(this);
    }
}
