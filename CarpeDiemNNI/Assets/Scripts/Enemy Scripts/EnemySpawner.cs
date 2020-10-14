using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate;
    public float minX, maxX;
    public float objectSpeedX, objectSpeedY;

    
    private float randX;
    private Vector2 spawnPoint;
    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTime)
        {
            spawnTime = Time.time + spawnRate;
            randX = Random.Range(minX, maxX);
            spawnPoint = new Vector2(randX, transform.position.y);
            Instantiate(enemy, spawnPoint, Quaternion.identity);
        }
    }
}
