using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public float lifeDrain;
    public string enemyTag, healthTag, moneyTag;

    public HealthBar healthBar;

    private float currentHealth;
    


    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.StartHealth(maxHealth);
    }
 
    private void Update()
    {
        currentHealth -= lifeDrain * Time.deltaTime;
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == enemyTag)
        {
            Debug.Log("Enemy Collision");
            currentHealth -= other.gameObject.GetComponent<EnemyCollider>().damageAmount;
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
