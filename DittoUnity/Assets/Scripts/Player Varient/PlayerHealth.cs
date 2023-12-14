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

    private bool touchingHazard;
    [SerializeField] private GameObject pickUpRange;
    private Collider2D pickUpCollider;

    public void Start()
    {
        touchingHazard = false;
        health = PlayerPrefs.GetFloat("PlayerHealth");
        currentSceneName = SceneManager.GetActiveScene().name;
        pickUpCollider = pickUpRange.GetComponent<Collider2D>();
        healthBar.fillAmount = health / maxHealth;
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemyBullet"))
        {
            Damage(1);
        }
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
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
        PlayerPrefs.SetFloat("PlayerHealth", health);
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
            
        }
        PlayerPrefs.SetFloat("PlayerHealth", health);
    }
}