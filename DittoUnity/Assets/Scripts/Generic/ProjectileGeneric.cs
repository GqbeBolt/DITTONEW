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

    public void OnTriggerEnter2D(Collider2D other)
    {

        foreach (string tag in breakTags)
        {

            if(other.gameObject.CompareTag(tag)){

                if (stickOnHit)
                {
                    transform.SetParent(other.transform);
                    Destroy(GetComponent<Rigidbody2D>());
                    Destroy(GetComponent<Collider2D>());
                    if (transform.childCount > 0)
                    {
                        Destroy(transform.GetChild(0).gameObject);
                    }
                    break;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

        
    }

    
}
