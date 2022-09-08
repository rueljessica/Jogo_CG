using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
    private Transform playerPosition;

    [SerializeField]
    private float zombieVelocity;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private bool onTheGround;

    [SerializeField]
    private Transform groundDetector;

    [SerializeField]
    private LayerMask whatIsGround;

    void Start() {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        followPlayer();
    }

    private void followPlayer() {
        if (playerPosition.gameObject != null) {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, zombieVelocity * Time.deltaTime);
        }
    }

}