using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthAndHurt : MonoBehaviour
{
    public float maxHealth;
    public float health;
    private Animator _animator;
    [SerializeField] private Slider slider;

    public void Start()
    {
        health = maxHealth;
        _animator = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("playerBullet"))
        {
            if(other.gameObject.name == "Player Fireball")
            {
                Damage(3f);
            } else
            {
                Damage(1f);
            }
            Debug.Log("E");
            
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerBullet"))
        {
            if (other.gameObject.name == "AreaDamage(Clone)")
            {
                Damage(3f);
            }
            else if (other.gameObject.name == "PlayerSlash(Clone)")
            {
                Damage(2f);
            }
            else
            {
                Damage(1f);
            }
        }
    }

    public void Damage(float amount)
    {
        health-=amount;
        _animator.Play("HurtAnim");
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        slider.value = health / maxHealth;
    }
}
