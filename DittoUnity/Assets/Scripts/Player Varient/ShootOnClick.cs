using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnClick : MonoBehaviour
{
    private ShootProjectile shooter;
    void Start()
    {
        shooter = GetComponent<ShootProjectile>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shooter.TryShoot();
        }
    }
}
