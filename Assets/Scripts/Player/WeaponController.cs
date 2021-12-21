using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Text points;
    [SerializeField] private GameObject damagePoint;

    private Vector2 _flyDirection = new(25, 20);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyDeadController>(out var deadController))
        {
            int pts = int.Parse(points.text);
            pts++;
            GameController.Instance.levelKills = pts;
            points.text = pts.ToString();
            var body = Instantiate(deadController.DeadbodyPrefab(), collision.gameObject.transform.localPosition, Quaternion.identity);
            Destroy(collision.gameObject);
            PlayDeathAnimation(body);
        }
    }

    public void AllowDamageCollision()
    {
        // do not delete, this method triggered from animation event
        damagePoint.SetActive(true);
    }


    public  void DenyDamageCollision()
    {
        // do not delete, this method triggered from animation event
        damagePoint.SetActive(false);
    }

    private void PlayDeathAnimation(GameObject body)
    {
        body.transform.DOMove(_flyDirection, 2f);
        Destroy(body, 3);
    }
}
