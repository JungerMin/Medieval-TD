using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject enemyPrefab;
        public int count;
        public float rate;
        public float waveCountdown = 2f;
    }

    public string enemyTag;

    public Wave[] waves;
    private int totalWaves;
    private int nextWave = 0;

    public static int EnemiesAlive = 0;

    private Transform spawnPoint;

    private float waveCountdown;
    private bool currentlySpawning = false;


    private void Start()
    {
        waveCountdown = waves[0].waveCountdown;
        totalWaves = waves.Length;
        nextWave = 0;
        EnemiesAlive = 0;
    }

    private void Update()
    {
        if (nextWave == totalWaves)
        {
            CheckAllEnemiesDefeated();
        }
        else
        {
            NextWave();
        } 
    }

    private void NextWave()
    {
        if (waveCountdown <= 0f)
        {
            if (!currentlySpawning && nextWave < totalWaves)
            {
                currentlySpawning = true;
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
            else
            {
                return;
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
            waveCountdown = Mathf.Clamp(waveCountdown, 0f, Mathf.Infinity);
        }
    }

    private void CheckAllEnemiesDefeated()
    {
        if (EnemiesAlive == 0)
        {
            GameManager.GameIsOver = true;
        }
        else
        {
            return;
        }
    }

    private IEnumerator SpawnWave(Wave _wave)
    {
        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemyPrefab);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        nextWave++;

        if (nextWave < totalWaves)
        {
            waveCountdown = waves[nextWave].waveCountdown;
        }

        currentlySpawning = false;

        yield break;
    }

    private void SpawnEnemy(GameObject _enemy)
    {
        spawnPoint = _enemy.GetComponent<EnemyMovement>().waypointsObject.GetComponent<Waypoints>().waypoints[0];
        GameObject e = Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
        e.SetActive(true);
        EnemiesAlive++;
    }
}
