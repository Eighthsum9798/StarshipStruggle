using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Projectile : MonoBehaviour
{
    // Time until the projectile is destroyed
    public float life = 3;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Destroy the projectile object after a certain amount of time
        Destroy(gameObject, life);
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if hitting enemy projectile
        if (collision.CompareTag("EProjectile"))
        {
            // Destroy the collided object
            Destroy(collision.gameObject);
            // Destroy the projectile object
            Destroy(gameObject);
        }
        else
        {
            // Destroy the collided object
            Destroy(collision.gameObject);
            // Destroy the projectile object
            Destroy(gameObject);
            // Increase the player's score when a projectile hits something
            Scoring.scoreCount += 50;
        }
        
    }
}
