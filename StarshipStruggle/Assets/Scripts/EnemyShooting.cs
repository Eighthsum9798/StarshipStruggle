using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float EProjectspeed = 10f;
    public Transform enemyprojectilespawnpoint;
    public GameObject EnemyProjectile;

    public float timeBetweenEShot = 1;
    public float lastEShot;

    public float rand = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rand = Random.Range(1, 20);

        if (rand >= 15 && Time.time >lastEShot + timeBetweenEShot)
        {
            var projectile = Instantiate(EnemyProjectile, enemyprojectilespawnpoint.position, enemyprojectilespawnpoint.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = enemyprojectilespawnpoint.right * EProjectspeed;

            lastEShot = Time.time;
        }
    }
}
