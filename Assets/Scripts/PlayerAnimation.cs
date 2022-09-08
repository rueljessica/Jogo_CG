using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Rigidbody2D rb;

    public Player player;

    void Update() {
        if(this.player.onTheGround) {
            float velocityX = Mathf.Abs(this.rb.velocity.x);
            if (velocityX > 0) {
                this.animator.SetBool("walk", true);
            }
            else {
                this.animator.SetBool("walk", false);
            }
        } else {
            float velocityY = this.rb.velocity.y;
            if(velocityY > 0) {
                this.animator.SetBool("jump", true);
            } else {
                this.animator.SetBool("jump", false);
            }
        }
    }
}
