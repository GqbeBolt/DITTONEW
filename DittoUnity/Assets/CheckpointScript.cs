using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetString("PlayerCheckpoint", SceneManager.GetActiveScene().name);
            PlayerPrefs.SetFloat("CheckpointWeapon", PlayerPrefs.GetFloat("PlayerHolding"));
        }
    }
}
