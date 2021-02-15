using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public double playerLight;
    public int maxPlayerLight;
    public int fireflys;
    public int souls;
    private Rigidbody2D rb;

    private void Awake() {
        rb = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    private void FixedUpdate() {
        float direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    private void Update() {
        if (playerLight > maxPlayerLight) {
            playerLight = maxPlayerLight;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Contains("Enemy")) {
            EnemyScript enermyscript = other.gameObject.GetComponent(typeof(EnemyScript)) as EnemyScript;

            if (enermyscript != null) {
                playerLight -= enermyscript.damage;
                if (transform.position.x - other.transform.position.x < 0) {
                    other.rigidbody.velocity = new Vector2(18, 0);
                } else {
                    other.rigidbody.velocity = new Vector2(-18, 0);
                }
            }
        }
    }
}