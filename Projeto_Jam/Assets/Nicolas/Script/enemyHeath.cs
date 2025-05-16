using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHeath : MonoBehaviour
{
    public BossHealth health;


    private void Awake()
    {
        health = GameObject.Find("Boss").GetComponent<BossHealth>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (health.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
