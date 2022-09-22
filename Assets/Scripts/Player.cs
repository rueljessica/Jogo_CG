using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int moveSpeed;
    [SerializeField] private Transform groundDetector;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private int extraJump = 1;
    [SerializeField] Animator animator;
    Object bulletPrefab;

    private float direction;
    private Vector3 facingRight;
    private Vector3 facingLeft;
    public bool onTheGround;

    private void Start() {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        rb = GetComponent<Rigidbody2D>();
        bulletPrefab = Resources.Load("Bullet");
    }


    void Update() {

        if (GameManeger.Instance == null) {
            return;
        }

        onTheGround = Physics2D.OverlapCircle(groundDetector.position, 0.2f, whatIsGround);

        if (Input.GetButtonDown("Jump") && onTheGround == true) {
            rb.velocity = Vector2.up * 12;
        }

        if (Input.GetButtonDown("Jump") && onTheGround == false && extraJump > 0) {
            rb.velocity = Vector2.up * 12;
            extraJump--;
        }

        if (onTheGround) {
            extraJump = 1;
        }

        if (onTheGround)
        {
            float velocityX = Mathf.Abs(this.rb.velocity.x);
            if (velocityX > 0)
            {
                this.animator.SetBool("walk", true);
            }
            else
            {
                this.animator.SetBool("walk", false);
            }
        }
        else
        {
            float velocityY = this.rb.velocity.y;
            if (velocityY > 0)
            {
                this.animator.SetBool("jump", true);
            }
            else
            {
                this.animator.SetBool("jump", false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("attack1");
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetTrigger("attack3");
            GameObject bullet = (GameObject)Instantiate(bulletPrefab);
            bullet.transform.position = new Vector3(transform.position.x + .4f, transform.position.y + .2f, -1);
        }

        if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("attack1")) {
            direction = Input.GetAxis("Horizontal");
            if (direction > 0) {
                transform.localScale = facingRight;
            }
            if (direction < 0) {
                transform.localScale = facingLeft;
            }
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }

        if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("attack3")) {
            direction = Input.GetAxis("Horizontal");
            if (direction > 0) {
                transform.localScale = facingRight;
            }
            if (direction < 0) {
                transform.localScale = facingLeft;
            }
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }
    }
} 