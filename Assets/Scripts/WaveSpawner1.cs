using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner1 : MonoBehaviour {

    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave {
        public string name;
        public Transform zombie;
        public int count;
        public float rate;

    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.COUNTING;

    void Start() {
        if (spawnPoints.Length == 0) {
            Debug.Log("No spawn points referenced.");
        }
        waveCountdown = timeBetweenWaves;
    }

    void Update() {

        if(state == SpawnState.WAITING) {
            if(ZombieIsAlive()) {
                WaveCompleted();
            } else {
                return;
            }
        }

        if(waveCountdown <= 0) {
            if(state != SpawnState.SPAWNING) {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        } else {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted() {
        Debug.Log("Wave Completed!");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave+1 > waves.Length-1) {
            nextWave = 0;
            Debug.Log("All waves complete! Looping...");
        } else {
            nextWave++;
        }
    }

    bool ZombieIsAlive() {
        searchCountdown -= Time .deltaTime;
        if(searchCountdown <= 0f){
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Zombie") == null) {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave) {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;
        for(int i=0; i<_wave.count; i++) {
            SpawnEnemy(_wave.zombie);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _zombie) {
        Debug.Log("Spawning enemy: " + _zombie.name);
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_zombie, _sp.position, _sp.rotation);
    }
}
