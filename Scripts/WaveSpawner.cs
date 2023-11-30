using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public int EnemiesAlive = 0;
    public Wave[] waves;

    public float timeBetweenWaves = 5f;
    public float countdown = 2f;

    public Text waveCountdownText;

    private int waveIndex = 0;
    public Transform spawnPoint;

    public GameManager gameManager;

    public bool test;


    void Start()
    {
        test = true;
    }
    private void Update()
    {

        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinGame();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            //StartCoroutine(SpawnWave());
            StartCoroutine("SpawnWave");
            countdown = timeBetweenWaves;
            return;
        }
        if (test == true) { 
            countdown -= Time.deltaTime;
        }
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
        EnemiesAlive = 0;
    }

    IEnumerator SpawnWave()
    {
        //countdown = timeBetweenWaves;

        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(0.5f);
            SpawnEnemy(wave.enemy1);
            yield return new WaitForSeconds(0.75f);
            SpawnEnemy(wave.enemy2);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
