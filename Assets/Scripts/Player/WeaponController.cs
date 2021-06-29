using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{

    [SerializeField] Text points;
    [SerializeField] private GameObject damagePoint;
    [SerializeField] private GameObject ratDeadPrefab;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            int pts = int.Parse(points.text);
            pts++;
            GameController.Instance.levelKills = pts;
            points.text = pts.ToString();

            EnemyDeadController deadController = collision.gameObject.GetComponent<EnemyDeadController>();

            var body = Instantiate(deadController.DeadbodyPrefab(), collision.gameObject.transform.localPosition, Quaternion.identity);

            Destroy(collision.gameObject);
            PlayDeathAnimation(body);
        }
    }

    void AllowDamageCollision()
    {
        damagePoint.SetActive(true);
    }


    void DenyDamageCollision()
    {
        damagePoint.SetActive(false);
    }

    public async void PlayDeathAnimation(GameObject body)
    {
        Vector2 flyDirection = new Vector2(25, 20);
        body.transform.DOMove(flyDirection, 2f);

        await Task.Delay(2500);
        Destroy(body);
    }
}
