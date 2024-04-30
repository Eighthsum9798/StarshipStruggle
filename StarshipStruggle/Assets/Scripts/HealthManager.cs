using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public int maxHealth = 50;
    public int currentHealth;
    public Healthbar healthbar;


    private bool isColliding = false;
    public float lastCollide;
    public float timeBetweenCollide = 1;

    public GameManager manager;

    private bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastCollide + timeBetweenCollide)
        {
            Debug.Log("reset");
            isColliding = false;

            if (currentHealth <= 0 && !isDead)
            {
                isDead = true;
                manager.gameOver();
                Debug.Log("dead");
            }
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isColliding && collision.CompareTag("Enemy"))
        {
            isColliding = true;

            Destroy(collision.gameObject);
            takeDamage(10);
        }
    }


    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

    }

    
}
