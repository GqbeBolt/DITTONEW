using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealthAndHurt : MonoBehaviour
{
    public float maxHealth;
    public float health;

    public void Start()
    {
        health = maxHealth;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("playerBullet"))
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
