using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float speed_delta = 7f;
    private float move_Speed = 1f;
    private RectTransform targetTransform;
    public int damage = 20;

    void Update()
    {
        transform.position = Vector3.MoveTowards(
                        transform.position, 
                        new Vector3(targetTransform.position.x, transform.position.y, 1f),
                        move_Speed * Time.deltaTime);
    }

    public void SetTargetPosition(RectTransform targetTransform, float move_Speed, float speed_delta) {
        this.move_Speed = Random.Range(move_Speed, move_Speed + speed_delta);
        this.targetTransform = targetTransform;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<PlayerHealth>().ApplyDamage(damage);
            Destroy(this.gameObject);
        }
    } 
}
