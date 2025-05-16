using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsDamage : MonoBehaviour
{
    public PlayerHealth health;

    private void Awake()
    {
        health = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            health.TakeDamage(8);
        }
    }
}
