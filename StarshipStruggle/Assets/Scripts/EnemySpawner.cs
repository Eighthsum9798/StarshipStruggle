using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public float enemySpeed = 10;

    public float timeBetweenSpawn = 1;
    public float lastSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >lastSpawn + timeBetweenSpawn)
        {
            int randEnemy = Random.Range(0, enemies.Length);
            int randSpawn = Random.Range(0, spawnPoints.Length);

            Instantiate(enemies[0], spawnPoints[randSpawn].position, transform.rotation);

            
            lastSpawn = Time.time;
        }
    }
}
