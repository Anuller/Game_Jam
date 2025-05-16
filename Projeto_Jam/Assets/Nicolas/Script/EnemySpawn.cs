using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefb;

    [SerializeField]
    private float minSpawnTime;

    [SerializeField]
    private float maxSpawnTime;

    public BossHealth health;

    private float spawnTime;

    void Awake()
    {
        SetTimeSpawn();

        health = GameObject.Find("Boss").GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            Instantiate(enemyPrefb, transform.position, Quaternion.identity);
            SetTimeSpawn();
        }

        if (health.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetTimeSpawn()
    {
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
