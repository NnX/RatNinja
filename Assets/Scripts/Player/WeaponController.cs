using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Text points;
    [SerializeField] private GameObject damagePoint;
    [SerializeField] private AudioSource[] hitSounds;
    
    private Vector3 _flyDirection = new(25, 20, 20);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyDeadController>(out var deadController))
        {
            hitSounds[Random.Range(0, hitSounds.Length)].Play();
            int pts = int.Parse(points.text);
            pts++;
            GameController.Instance.levelKills = pts;
            points.text = pts.ToString();
            var localPosition = collision.gameObject.transform.position;
            var body = Instantiate(deadController.DeadbodyPrefab(), localPosition, Quaternion.identity);

            if (collision.TryGetComponent<IResetable>(out var  resetable))
            {
                resetable.Disable();
                PlayDeathAnimation(body);
            }
            else
            {
                Destroy(collision.gameObject);
            }
            PlayDeathAnimation(body);
        }
    }

    public void AllowDamageCollision()
    {
        // do not delete, this method triggered from animation event
        GameController.Instance.SetSpeed();
        damagePoint.SetActive(true);
    }
    public void DenyDamageCollision()
    {
        // do not delete, this method triggered from animation event
        GameController.Instance.ResetSpeed();
        damagePoint.SetActive(false);
    }

    private void PlayDeathAnimation(GameObject body)
    {
        body.transform.DOMove(_flyDirection, 2f);
        Destroy(body, 3);
    }
}
