using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public float lifeDrain;
    public float speed = 5f;

    public HealthBar healthBar;


    private Rigidbody2D rb2D;
    private float currentHealth;

    public void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.StartHealth(maxHealth);
    }

    private Vector2 movement = Vector3.zero;
    private void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + movement * speed * Time.fixedDeltaTime);
        currentHealth -= (lifeDrain * Time.fixedDeltaTime);
        healthBar.SetHealth(currentHealth);
    }
}
