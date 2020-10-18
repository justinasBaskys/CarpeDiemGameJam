using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    public float startFireRate;
    public float startDelay;
    public float bulletForce;
    public float animationTime;
    public string targetTagName;
    public int shotsMax;

    private int shotsTaken;
    private float fireRate;
    private Transform target;

    public Transform firepoint;
    public GameObject bulletPrefab;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        shotsTaken = 0;
        target = GameObject.FindGameObjectWithTag(targetTagName).transform;
        fireRate = startFireRate + startDelay; // instead of IF && in update.
    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime; // might not need the else statement, for further review.    
        if (fireRate < animationTime && shotsTaken < shotsMax)
		{
            animator.SetTrigger("Shoot");
		}
        if (fireRate <= 0 && shotsTaken < shotsMax)
		{
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce((target.position - transform.position).normalized * bulletForce, ForceMode2D.Impulse);
            fireRate = startFireRate;
            animator.ResetTrigger("Shoot");
            shotsTaken += 1;
        }  
    }
}
