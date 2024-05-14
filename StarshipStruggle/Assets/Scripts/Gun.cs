using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Reference to the spawn point of projectiles
    public Transform projectileSpawnPoint;

    // Projectile prefabs
    public GameObject projectile1; // For regular projectiles
    public GameObject projectile2; // For special projectiles

    // Projectile speeds
    public float projectileSpeed = 10; // Speed of regular projectiles
    public float projectileSpeed2 = 5; // Speed of special projectiles

    // Time between shots for special projectile
    public float timeBetweenShot = 3;

    private float lastShot; // Time when the last shot occurred

    // Audio variables
    public AudioSource source; // Audio source component
    public AudioClip machineGun; // Sound for regular projectiles
    public AudioClip cannon; // Sound for special projectiles



    // Update is called once per frame
    void Update()
    {
        // Check if the "Keypad8" key is pressed for regular projectile
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            // Instantiate a regular projectile at the spawn point
            var projectile = Instantiate(projectile1, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            // Set velocity of the projectile
            projectile.GetComponent<Rigidbody2D>().velocity = projectileSpawnPoint.right * projectileSpeed;
            // Play sound for regular projectile
            source.PlayOneShot(machineGun);
        }

        // Check if the "Keypad9" key is pressed for special projectile and enough time has passed since the last shot
        else if (Input.GetKeyDown(KeyCode.Keypad9) && Time.time > lastShot + timeBetweenShot)
       {
            // Instantiate a special projectile at the spawn point
            var projectile = Instantiate(projectile2, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            // Set velocity of the projectile
            projectile.GetComponent<Rigidbody2D>().velocity = projectileSpawnPoint.right * projectileSpeed2;
            // Record the time of the last shot
            lastShot = Time.time;
            // Play sound for special projectile
            source.PlayOneShot(cannon);
       }

        
        
      
    }
}
