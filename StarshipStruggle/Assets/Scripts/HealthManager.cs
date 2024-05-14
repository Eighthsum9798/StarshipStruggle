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

    public AudioSource source;
    public AudioClip damaged;
    


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
                Destroy(gameObject);
                manager.gameOver();
                Debug.Log("dead");
                Time.timeScale = 0f;
                DestroyEnemiesWithTag("Enemy");

            }
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isColliding && collision.CompareTag("Enemy") || collision.CompareTag("EProjectile")) 
        {
            isColliding = true;

            Destroy(collision.gameObject);
            takeDamage(10);
            source.PlayOneShot(damaged);
        }
    }


    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

    }

    void DestroyEnemiesWithTag(string tag)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }


}
