using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
