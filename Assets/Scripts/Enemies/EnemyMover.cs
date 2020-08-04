using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float move_Speed = 1f;
    private RectTransform targetTransform;


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetTransform.position.x,
                                   targetTransform.position.y - 0.9f, 0f),
                       move_Speed * Time.deltaTime);
    }

    public void SetTargetPosition(RectTransform targetTransform) {
        this.targetTransform = targetTransform;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Debug.Log("OnTriggerEnter2D" + collision.name);
    }
}
