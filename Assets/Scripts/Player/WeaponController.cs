using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{

    [SerializeField] Text points; 
    [SerializeField] private GameObject damagePoint;
    [SerializeField] private GameObject ratDeadPrefab;


    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Enemy") {
            int pts = System.Int32.Parse(points.text);
            pts++;
            GameController.Instance.levelKills = pts;
            points.text = pts.ToString();

            var enemy = Instantiate(ratDeadPrefab, collision.gameObject.transform.localPosition, Quaternion.identity);

            float scaleX = collision.gameObject.transform.localScale.x;
            Destroy(collision.gameObject);
            enemy.GetComponent<EnemyDeadController>().PlayDeath(scaleX);
        }
    }

    void AllowDamageCollision() {
        damagePoint.SetActive(true);
    }


    void DenyDamageCollision() {
        damagePoint.SetActive(false);
    }
}
