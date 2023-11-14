using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGeneric : MonoBehaviour
{
    public string[] breakTags;
    public bool stickOnHit;
    public float despawnTime;

    public void Start()
    {
        Destroy(gameObject, despawnTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        foreach (string tag in breakTags)
        {
            if(other.CompareTag(tag)){
                if (stickOnHit)
                {
                    Destroy(GetComponent<Rigidbody2D>());
                    Destroy(GetComponent<Collider2D>());
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

        
    }
}
