using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public float lifeDrain;
    public float gravityScale;
    public string enemyTag, healthTag, moneyTag;

    public PlayerMovement playerMovement;
    public Animator animator;
    public HealthBar healthBar;
    public Rigidbody2D rigidBody;

    private float currentHealth;
    private bool isAlive;

    public void Start()
    {
        Debug.Log("start");
        currentHealth = maxHealth;
        healthBar.StartHealth(maxHealth);
        isAlive = true;
        rigidBody.gravityScale = 0;
    }
 
    private void Update()
    {
        currentHealth -= lifeDrain * Time.deltaTime;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0 && isAlive)
        {
            Debug.Log("Player was killed");
            animator.SetTrigger("Death");
            playerMovement.enabled = false;
            rigidBody.gravityScale = 1;
            isAlive = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == enemyTag)
        {
            Debug.Log("Enemy Collision");
            currentHealth -= other.gameObject.GetComponent<Enemy>().damageAmount;
            animator.SetTrigger("Damage");
            Destroy(other.gameObject);
        }
        if(other.tag == healthTag)
        {
            Debug.Log("Health Collision");
            currentHealth += other.gameObject.GetComponent<HealthPickup>().healthAmount;
            Destroy(other.gameObject);
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
        if(other.tag == moneyTag)
        {
            Debug.Log("Money Collision");
        }
    }
}
