using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {

    [SerializeField] private bool alive = true;

    void Update() {
        GameManeger.Instance.refreshScreen();
    }

    public void loseLife() {
        if(alive) {
            alive = false;
            gameObject.GetComponent<Animator>().SetTrigger("hurt");
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            gameObject.GetComponent<Player>().enabled = false;
            gameObject.GetComponent<Animator>().SetBool("walk", false);
            GameManeger.Instance.setLives(-1);
            Invoke("loadScene", 1f);

            if(GameManeger.Instance.lives <= 0) {
                Debug.Log("Game Over!");
                GameManeger.Instance.lives = 0;
                Invoke("loadScene", 1f);
            } 
        }
    }

    void loadScene() {
        SceneManager.LoadScene("Game");
    }
}
