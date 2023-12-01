using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnDeath : MonoBehaviour
{
    public GameObject deathParticle;
    
    private bool isQuitting = false;

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public void OnDestroy(){
        
        if (!isQuitting)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
        }
    }
}