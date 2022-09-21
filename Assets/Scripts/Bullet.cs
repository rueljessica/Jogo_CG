using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour {
    [SerializeField] private float speed;
    private Vector2 direction;
    protected Rigidbody2D rb;
    protected Animator animator;
    public GameObject bullet;
    protected float livingTime = 3f;

    protected virtual void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = bullet.GetComponent<Animator>();
    }

    protected virtual void Start()
    {
        Destroy(gameObject, livingTime);
    }

    protected virtual void FixedUpdate() {
        movement();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Zombie") {
            StartCoroutine("Destroy");
        }
    }

    void movement() {
        Vector2 movement = direction.normalized * speed;
        rb.velocity = movement;
    }

    void explode() {
        speed = 0f;
        GetComponent<BoxCollider2D>().enabled = false;
        if(bullet != null) {
            bullet.SetActive(true);
        }
        Destroy(gameObject, 1.5f);
    }
}
