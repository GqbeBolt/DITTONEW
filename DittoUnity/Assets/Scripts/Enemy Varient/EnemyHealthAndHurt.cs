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
    private Animator _animator;

    public void Start()
    {
        health = maxHealth;
        _animator = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("playerBullet"))
        {
            health--;
            _animator.Play("HurtAnim");
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerBullet"))
        {
            health--;
            _animator.Play("HurtAnim");
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
