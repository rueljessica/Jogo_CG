using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float distMin;
    [SerializeField] private int energy;
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

        if(energy <= 0) {
            animator.SetTrigger("dead");
            Invoke("destroyBody", .5f);
        }
    }

    public void takeDamage(int damage) {
        energy -= damage;
    }

    private void destroyBody() {
        Destroy(gameObject);
    }
}