using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnDeath : MonoBehaviour
{
    public GameObject deathParticle;
    public int chance = 100;
    
    private bool isQuitting = false;

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public void OnDestroy(){
        
        if (!isQuitting && Random.Range(1, 100) <= chance)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
        }
    }
}