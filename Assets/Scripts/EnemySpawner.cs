using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups; //list of groups of enemies to spawn in this wave
        public int waveQuota; //total enemy spawn count
        public float spawnInterval; //spawn interval
        public int spawnCount; //number of enemies alredy spawned
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount; //number of enemies to spawn in this wave
        public int spawnCount; //number of enemies of this type already spawned in this wave
        public GameObject enemyPrefab;
    }

    public List<Wave> waves; //list of waves in the game
    public int currentWaveCount; //index of current wave

    [Header("Spawner Attributes")]
    float spawnTimer; //timer used to determine when to spawn the next enemy
    public int enemiesAlive;
    public int maxEnemiesAllowed; //max amount of enemies allowed to be on the map at once
    public bool maxEnemiesReached = false; //indicates if the max amount of enemies has been reached
    public float waveInterval; //interval between waves

    [Header("Spawn Positons")]
    public List<Transform> relativeSpawnPoints; //list to store relative spawn points of enemies

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
        CalculateWaveQuota();
    }

    // Update is called once per frame
    void Update()
    {
        //check if wave has ended & if next wave should start
        if (currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0)
        {
            StartCoroutine(BeginNextWave());
        }

        spawnTimer += Time.deltaTime;

        //check if it's time to spawn the next enemy
        if(spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }

    IEnumerator BeginNextWave()
    {
        yield return new WaitForSeconds(waveInterval);

        if (currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;
            CalculateWaveQuota();
        }
    }

    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }

        waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);
    }

    void SpawnEnemies()
    {
        //checks if minimum number of enemies in the wave has been spawned
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota)
        {
            //spawn each type until quota is filled
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                //check if minimum number of enemies of this type has been spawned
                if (enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    //limits amount of enemies that can be spawned at one time
                    if (enemiesAlive >= maxEnemiesAllowed)
                    {
                        maxEnemiesReached = true;
                        return;
                    }

                    //spawn enemy at a random position near the player
                    Instantiate(enemyGroup.enemyPrefab, player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);

                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                    enemiesAlive++;
                }
            }

            if(enemiesAlive < maxEnemiesAllowed)
            {
                maxEnemiesReached = false;
            }
        }
    }

    public void OnEnemyKilled()
    {
        enemiesAlive--; 
    }
}