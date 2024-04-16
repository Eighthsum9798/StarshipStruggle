using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform projectileSpawnPoint;
    public GameObject projectile1;
    public float projectileSpeed = 10;

   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            var projectile = Instantiate(projectile1, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = projectileSpawnPoint.right * projectileSpeed;
        }
    }
}
