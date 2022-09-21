using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 direction;
    void Start() {
        direction = Vector2.right;
    }

    // Update is called once per frame
    void FixedUpdate() {
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Zombie") {
            StartCoroutine("destroy");
        }
    }

    IEnumerator destroy() {
        yield return new WaitForSeconds(0.08f);
        Destroy(gameObject);
    }

    public void init(Vector2 _direction)
    {
        direction = _direction;
    }
}
