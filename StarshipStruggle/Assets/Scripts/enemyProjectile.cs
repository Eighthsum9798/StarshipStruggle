using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{


    // Time until the projectile is destroyed
    public float life = 3;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Destroy the projectile object after a certain amount of time
        Destroy(gameObject, life);
    }
    

    
}
