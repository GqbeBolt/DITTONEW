using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float health;
    private Animator _animator;
    private string currentSceneName;

    public void Start()
    {
        health = maxHealth;
        currentSceneName = SceneManager.GetActiveScene().name;
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemyBullet"))
        {
            health--;
            if (health <= 0)
            {
               
                SceneManager.LoadScene(currentSceneName);
            }
        }
    }
}