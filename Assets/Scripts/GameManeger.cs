using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    private int maxZombiesToSpawn = 3;
    private static GameManeger instance;
    public static GameManeger Instance => instance;

    public Text lifeText;
    public int lives = 1;

    private void Awake() {
        refreshScreen();
    }

    void Start() {
        instance = this;
        StartCoroutine(SpawnZombies());
    }

    public void Enable() {
        gameObject.SetActive(true);
    }

    private IEnumerator SpawnZombies() {
        var zombieToSpawn = Random.Range(1, maxZombiesToSpawn);
        for(int i=0; i<zombieToSpawn; i++) {
            var x = Random.Range(-70, 70);
            Instantiate(zombiePrefab, new Vector3(x, -13, 0), Quaternion.identity);
        }
        yield return new WaitForSeconds(5f);
        yield return SpawnZombies();
    }

    public void setLives(int life) {
        lives += life;
        if(lives >= 0) {
            refreshScreen();
        }
    }

    public void refreshScreen() {
        lifeText.text = lives.ToString();
    }
}
