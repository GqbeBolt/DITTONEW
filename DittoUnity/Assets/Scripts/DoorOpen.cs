using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DoorOpen : MonoBehaviour
{
    public bool open, playerNear;
    private SpriteRenderer sr;

    [SerializeField] Sprite openSprite;
    [SerializeField] string nextScene;
    private GameObject player;
    private TMP_Text text; 

    void Start()
    {
        open = false;
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        text = player.GetComponentInChildren<TMP_Text>();
    }
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            open = true;
            sr.sprite = openSprite;
        }
        if (open && playerNear && Input.GetKey(KeyCode.W))
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && open)
        {
            playerNear = true;
            text.text = "Press <W> to enter door";
        }
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && open)
        {
            playerNear = false;
            text.text = "";
        }
    }

   
}
