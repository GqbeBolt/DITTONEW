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
    [SerializeField] private Camera camera;

    public void Start()
    {
        health = maxHealth;
        _animator = GetComponent<Animator>();
        camera = 
    }

    public void FixedUpdate()
    {
        slider.transform.rotation = camera.transform.rotation;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("playerBullet"))
        {
            Damage(1f);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerBullet"))
        {
            Damage(1f);
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
