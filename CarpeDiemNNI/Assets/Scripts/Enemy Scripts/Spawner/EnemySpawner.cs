using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate;
    public float itemForce;
    public float startTime;

    public GameObject[] spawnItems;
    public Transform[] spawnPoints;
    
    private float spawnTime;
    private void Start()
    {
        spawnTime = startTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            spawnTime = Time.time + spawnRate;
            int randomItem = Random.Range(0, spawnItems.Length);
            int randSpawn = Random.Range(0, spawnPoints.Length);
            GameObject spawnedObject = Instantiate(spawnItems[randomItem], spawnPoints[randSpawn].position, transform.rotation);
            Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
            rb.AddForce(spawnPoints[randSpawn].up * itemForce, ForceMode2D.Impulse);
        }
    }
}
