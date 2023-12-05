using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGeneric : MonoBehaviour
{
    public string[] breakTags;
    public bool stickOnHit;
    public float despawnTime;

    public bool rotateWithGravity;
    private Rigidbody2D _rigidbody2D;

    public void Start()
    {
        Destroy(gameObject, despawnTime);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        if (rotateWithGravity && _rigidbody2D)
        {
            transform.right = _rigidbody2D.velocity;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("I am: " + gameObject.GetInstanceID());
        Debug.Log("I hit: " + other.gameObject.GetInstanceID());
        foreach (string tag in breakTags)
        {
            Debug.Log("Checking tag: " + tag);
            Debug.Log("Other is: " + other.gameObject.name);
            if(other.gameObject.CompareTag(tag)){
                Debug.Log("Hit tag: " + tag);
                Debug.Log("Other is: " + other.gameObject.name);
                if (stickOnHit)
                {
                    Debug.Log("Stick on hit");
                    Debug.Log("Other is: " + other.gameObject.name);
                    transform.SetParent(other.transform);
                    Destroy(GetComponent<Rigidbody2D>());
                    Destroy(GetComponent<Collider2D>());
                    Debug.Log("Parent is: " + transform.parent.name);
                    break;
                }
                else
                {
                    Destroy(gameObject);
                }
                Debug.Log("Loop is still running");
            }
        }

        
    }
}
