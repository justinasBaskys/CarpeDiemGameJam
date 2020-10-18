using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public float lifeDrain;
    public float gravityScale;
    public string enemyTag, healthTag, moneyTag, enemyInvTag;

    public PlayerMovement playerMovement;
    public Animator animator;
    public HealthBar healthBar;
    public Rigidbody2D rigidBody;
    public GameManager gameManager;
    public PolygonCollider2D playerCollider;

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
            playerCollider.enabled = false;
            rigidBody.gravityScale = 1;
            isAlive = false;
            FindObjectOfType<GameManager>().EndGame();

        }
    }

    public void HealPlayer(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == enemyTag || other.tag == enemyInvTag) //Handles collisions between enemy and player
        {
            Debug.Log("Enemy Collision");
            HealPlayer(-other.gameObject.GetComponent<Enemy>().damageAmount);
            animator.SetTrigger("Damage");
            if (other.tag != enemyInvTag) // If enemy is not tagged as invincible "enemyInvTag" they will be destroyed.
            {
                Destroy(other.gameObject);
            }
        }
        if (other.tag == healthTag)
        {
            Debug.Log("Health Collision");
            HealPlayer(other.gameObject.GetComponent<HealthPickup>().healthAmount);
            Destroy(other.gameObject);
        }
        if (other.tag == moneyTag)
        {
            Debug.Log("Money Collision");
        }
    }
}