using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private  Rigidbody2D rb;

    [SerializeField]
    private int moveSpeed;

    private float direction;
    private Vector3 facingRight;
    private Vector3 facingLeft;
    public bool onTheGround;

    [SerializeField]
    private Transform groundDetector;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private int extraJump = 1;

    private void Start() {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        onTheGround = Physics2D.OverlapCircle(groundDetector.position, 0.2f, whatIsGround);

        if (Input.GetButtonDown("Jump") && onTheGround == true) {
            rb.velocity = Vector2.up * 12;
        }

        if (Input.GetButtonDown("Jump") && onTheGround == false && extraJump>0) {
            rb.velocity = Vector2.up * 12;
            extraJump--;
        }

        if(onTheGround) {
            extraJump = 1;
        }

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