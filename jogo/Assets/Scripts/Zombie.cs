using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zombie : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float distMin;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Animator animator;


    void Update() {
        Vector2 playerPosition = this.player.position;
        Vector2 actualPosition = this.transform.position;

        float dist = Vector2.Distance(actualPosition, playerPosition);
        if(dist >= this.distMin) {
            Vector2 direction = playerPosition - actualPosition;
            direction = direction.normalized;

            this.rb.velocity = (this.speed * direction);

            if (this.rb.velocity.x > 0) {
                this.sr.flipX = false;
            }
            else if (this.rb.velocity.x < 0) {
                this.sr.flipX = true;
            }
        } else {
            this.rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<PlayerLife>().loseLife();
        }
    }
}