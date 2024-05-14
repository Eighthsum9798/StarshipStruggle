using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Time until the enemy is destroyed
    public float life = 5;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Destroy the enemy object after a certain amount of time
        Destroy(gameObject, life);
    }

    // Speed of the enemy movement
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the enemy to the left based on its speed
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
