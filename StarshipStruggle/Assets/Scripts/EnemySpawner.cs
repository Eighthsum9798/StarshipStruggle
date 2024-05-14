using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    // array of spawn points where enemies can spawn.
    public Transform[] spawnPoints;

    //array of enemy prefabs that can spawn
    public GameObject[] enemies;

    //speed of spawned enemies
    public float enemySpeed = 10;

    // Time variables for spawning
    public float timeBetweenSpawn = 1; // Time between each spawn

    public float lastSpawn; // Time when the last spawn occurred

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if enough time has passed since the last spawn
        if (Time.time >lastSpawn + timeBetweenSpawn)
        {
            // Generate random index for selecting enemy and spawn point
            int randEnemy = Random.Range(0, enemies.Length); // Random index for enemy selection
            int randSpawn = Random.Range(0, spawnPoints.Length); // Random index for spawn point selection

            // Instantiate a random enemy at a random spawn point
            Instantiate(enemies[randEnemy], spawnPoints[randSpawn].position, transform.rotation);

            // Update the last spawn time to current time
            lastSpawn = Time.time;
        }
    }
}
