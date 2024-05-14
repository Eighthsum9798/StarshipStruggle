using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //health variables
    public int maxHealth = 50; // Maximum health
    public int currentHealth; // Current health
    public Healthbar healthbar; // Reference to the health bar UI

    // Collision variables
    private bool isColliding = false; // Flag to prevent multiple collisions in a short time
    public float lastCollide; // Time of the last collision
    public float timeBetweenCollide = 1; // Time interval required between collisions

    // Game manager reference
    public GameManager manager; // Reference to the game manager

    // Death handling
    private bool isDead; // Flag to track if the player is dead

    //audio variables
    public AudioSource source; // Audio source component
    public AudioClip damaged; // Sound played when damaged



    // Start is called before the first frame update
    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;

        // Set maximum health on the health bar UI
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Reset collision flag if enough time has passed
        if (Time.time > lastCollide + timeBetweenCollide)
        {
            Debug.Log("reset");

            isColliding = false;

            // Check if player health is zero and it's not dead
            if (currentHealth <= 0 && !isDead)
            {
                // Set the player as dead
                isDead = true;

                // Destroy the player object
                Destroy(gameObject);

                // Trigger game over in the game manager
                manager.gameOver();

                // Log player's death
                Debug.Log("dead");

                // Pause the game
                Time.timeScale = 0f;

                // Destroy all enemies and projectiles
                DestroyEnemiesWithTag("Enemy");
                DestroyEnemiesWithTag("Projectile");
                DestroyEnemiesWithTag("EProjectile");
            }
        }
    }



    // Method to handle collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if not already colliding and the collision is with an enemy or enemy projectile
        if (!isColliding && collision.CompareTag("Enemy") || collision.CompareTag("EProjectile")) 
        {
            // Set as colliding to prevent further collisions
            isColliding = true;

            // Destroy the collided object
            Destroy(collision.gameObject);

            // Inflict damage to the player
            takeDamage(10);

            // Play damaged audio clip
            source.PlayOneShot(damaged);
        }
    }


    // Method to inflict damage to the player
    public void takeDamage(int damage)
    {
        // Decrease current health by the damage amount
        currentHealth -= damage;
        // Update health bar UI
        healthbar.SetHealth(currentHealth);

    }

    // Method to destroy game objects with a specified tag
    void DestroyEnemiesWithTag(string tag)
    {
        // Find all game objects with the specified tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        // Loop through each enemy object and destroy it
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        // Find all game objects with the specified tag
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag(tag);
        // Loop through each projectile and destroy it
        foreach (GameObject projectile in projectiles)
        {
            Destroy(projectile);
        }

        // Find all game objects with the specified tag
        GameObject[] EProjectiles = GameObject.FindGameObjectsWithTag(tag);
        // Loop through each enemy projectile and destroy it
        foreach (GameObject projectile in EProjectiles)
        {
            Destroy(projectile);
        }
    }


}
