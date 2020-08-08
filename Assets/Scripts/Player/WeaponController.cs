using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{

    [SerializeField] Text points; 
    [SerializeField] private GameObject damagePoint;


    private void OnTriggerEnter2D(Collider2D collision) {

        Debug.Log($"WeaponController collision = {collision.gameObject.tag}");
        if (collision.tag == "Enemy") {
            int pts = System.Int32.Parse(points.text);
            pts++;
            points.text = pts.ToString();
            Debug.Log("Killed = " + collision.gameObject.tag);
            Destroy(collision.gameObject);
        }
    }

    void AllowDamageCollision() {
        damagePoint.SetActive(true);
    }


    void DenyDamageCollision() {
        damagePoint.SetActive(false);
    }
}
