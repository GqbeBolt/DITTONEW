using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticleOnDeath : MonoBehaviour
{
    public ParticleSystem deathParticle;
    
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
