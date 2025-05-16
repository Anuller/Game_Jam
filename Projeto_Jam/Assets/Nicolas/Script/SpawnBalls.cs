using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    public GameObject BallsPrefb;

    public float spawnTime, spawnDelay;

    void Start()
    {
        InvokeRepeating("SpawnRandom", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void SpawnRandom()
    {
        Instantiate(BallsPrefb, transform.position, transform.rotation);
    }
}
