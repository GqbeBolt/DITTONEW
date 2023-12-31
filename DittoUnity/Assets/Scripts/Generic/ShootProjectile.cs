using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float additionalSpeed;

    public float cooldown;
    private float cooldownTimeStamp;

    public void TryShoot()
    {
        if (Time.time < cooldownTimeStamp)
        {
            return;
        }

        cooldownTimeStamp = Time.time + cooldown;
        Shoot();
    }
    public void Shoot()
    {
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
        //velocity = 1,0 * (extra speed * flip velocity if facing otherway)
        
        proj.GetComponent<Rigidbody2D>().velocity = transform.right*(transform.parent.transform.localScale.x*additionalSpeed);
        proj.transform.right = proj.GetComponent<Rigidbody2D>().velocity;
    }
}
