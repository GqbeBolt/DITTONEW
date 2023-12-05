using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth;
    public float health;
    private Animator _animator;
    private string currentSceneName;
    
    public float cooldown;
    private float cooldownTimeStamp;

    private Boolean touchingHazard;

    public void Start()
    {
        touchingHazard = false;
        health = maxHealth;
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    public void FixedUpdate()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(currentSceneName);
        }
        
        if (touchingHazard)
        {
            if (Time.time < cooldownTimeStamp)
            {
                return;
            }

            cooldownTimeStamp = Time.time + cooldown;
            Damage(1);
        }
        
        healthBar.fillAmount = health / maxHealth;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemyBullet"))
        {
            Damage(1);
        }

        if (other.gameObject.CompareTag("spikes"))
        {
            touchingHazard = true;
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("spikes"))
        {
            touchingHazard = false;
        }
    }


    public void Damage(int amount)
    {
        health -= amount;
    }
}