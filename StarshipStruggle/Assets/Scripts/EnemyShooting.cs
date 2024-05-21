using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    // Projectile speed
    public float EProjectspeed = 10f;
    // Reference to the spawn point of enemy projectiles
    public Transform enemyprojectilespawnpoint;
    // Enemy projectile prefab
    public GameObject EnemyProjectile;

    // Time variables for shooting
    public float timeBetweenEShot = 1f; // Time between each enemy shot
    public float lastEShot; // Time when the last enemy shot occurred

    // Random variable to determine when to shoot
    public float rand = 0f;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Generate a random number between 1 and 20
        rand = Random.Range(1, 20);

        // Check if the random number is greater than or equal to 15 and if enough time has passed since the last shot
        if (rand >= 15 && Time.time >lastEShot + timeBetweenEShot)
        {
            // Instantiate an enemy projectile at the spawn point
            var projectile = Instantiate(EnemyProjectile, enemyprojectilespawnpoint.position, enemyprojectilespawnpoint.rotation);
            // Set velocity of the projectile
            projectile.GetComponent<Rigidbody2D>().velocity = enemyprojectilespawnpoint.right * EProjectspeed;
            // Record the time of the last shot
            lastEShot = Time.time;
            

        }
    }
}
