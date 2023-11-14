using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float additionalSpeed;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
        //velocity = 1,0 * (extra speed * flip velocity if facing otherway)
        
        proj.GetComponent<Rigidbody2D>().velocity = transform.right*(transform.parent.transform.localScale.x*additionalSpeed);
    }
}
