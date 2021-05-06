using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemyPrefab;
        public int count;
        public float rate;
        public float waveCountdown = 2f;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform spawnPoint;

    public float waveCountdown;
    private float searchCountdown = 1f;

    public Text waveCountdownText;

    private SpawnState state = SpawnState.COUNTING;

    private void Start()
    {
        waveCountdown = waves[0].waveCountdown;
    }

    private void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
        }

        if (state == SpawnState.WAITING)
        {   
            //Check if all enemies of one wave are dead
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                /*  WaveCompleted() for don't wait till all enemies dead
                 *  return for wait till all enemies dead
                 */
                WaveCompleted();
            }
        }

        //Spawn new wave if countdown reaches 0
        if (waveCountdown <= 0f)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
            waveCountdown = Mathf.Clamp(waveCountdown, 0f, Mathf.Infinity);
        }
    }

    private void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("ALL WAVE COMPLETE! Looping...");
        }
        else
        {
            nextWave++;
        }

        waveCountdown = waves[nextWave].waveCountdown;
    }

    private bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if(GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    private IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave");
        state = SpawnState.SPAWNING;

        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemyPrefab);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpawnState.WAITING;

        Debug.Log("Wave Spawned!");

        yield break;
    }

    private void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Spawning Enemy: " + _enemy.name);
    }
}
