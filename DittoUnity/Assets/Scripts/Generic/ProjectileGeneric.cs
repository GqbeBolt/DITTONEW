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
        foreach (string tag in breakTags)
        {
            if(other.gameObject.CompareTag(tag)){
                if (stickOnHit)
                {
                    Destroy(GetComponent<Rigidbody2D>());
                    Destroy(GetComponent<Collider2D>());
                    transform.parent = other.transform;
                    Debug.Log(other.gameObject.name);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

        
    }
}
