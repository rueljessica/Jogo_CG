using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    private int maxZombiesToSpawn = 2;
    private static GameManeger instance;
    public static GameManeger Instance => instance;


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
            var x = Random.Range(-25, 25);
            Instantiate(zombiePrefab, new Vector3(x, -13, 0), Quaternion.identity);
        }
        yield return new WaitForSeconds(5f);
        yield return SpawnZombies();
    }
}
