using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour
{
    public bool open;
	private static int levelNum = 0;
    private SpriteRenderer sr;

    [SerializeField] Sprite openSprite;
    // Update is called once per frame

    void Start()
    {
        open = false;
        sr = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            open = true;
            sr.sprite = openSprite;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (open && other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.W))
        {
            levelNum++;
            Debug.Log(levelNum);
            SceneManager.LoadScene("Level" + levelNum/2);
            
        }
    }
}
