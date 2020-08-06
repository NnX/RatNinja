using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float move_Speed = 1f;
    private RectTransform targetTransform;
    public int damage = 20;

    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetTransform.position.x,
                                   targetTransform.position.y, 1f),
                       move_Speed * Time.deltaTime);
    }

    public void SetTargetPosition(RectTransform targetTransform) {
        this.targetTransform = targetTransform;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<PlayerHealth>().ApplyDamage(damage);
            Destroy(this.gameObject);
        }
    } 
}
