using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform projectileSpawnPoint;

    public GameObject projectile1;
    public GameObject projectile2;

    public float projectileSpeed = 10;
    public float projectileSpeed2 = 5;

    public float timeBetweenShot = 3;

    private float lastShot;

    public AudioSource source;
    public AudioClip machineGun;
    public AudioClip cannon;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            var projectile = Instantiate(projectile1, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = projectileSpawnPoint.right * projectileSpeed;
            source.PlayOneShot(machineGun);
        }


       else if (Input.GetKeyDown(KeyCode.Keypad9) && Time.time > lastShot + timeBetweenShot)
       {
            var projectile = Instantiate(projectile2, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = projectileSpawnPoint.right * projectileSpeed2;
            lastShot = Time.time;
            source.PlayOneShot(cannon);
       }
        
      
    }
}
