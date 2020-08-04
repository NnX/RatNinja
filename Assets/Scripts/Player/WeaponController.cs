using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Enemy") {
            Debug.Log("Killed = " + collision.gameObject.tag);
            Destroy(collision.gameObject);
        }
    }
}
