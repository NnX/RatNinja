using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{

    [SerializeField] Text points; 

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Enemy") {
            int pts = System.Int32.Parse(points.text);
            pts++;
            points.text = pts.ToString();
            Debug.Log("Killed = " + collision.gameObject.tag);
            Destroy(collision.gameObject);
        }
    }
}
