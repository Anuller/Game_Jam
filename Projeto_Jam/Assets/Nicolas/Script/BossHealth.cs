using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public static BossHealth Instance;

    public float maxHealth = 100;
    public float currentHealth;

    public BarBoss healthBar;

    public float damageBoss;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        GameController.Instance.sfxsource.volume = currentHealth/100;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("DamegeBoss"))
        {
            TakeDamage(damageBoss);
        }
    }
}
