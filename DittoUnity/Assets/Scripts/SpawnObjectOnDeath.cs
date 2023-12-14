using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnObjectOnDeath : MonoBehaviour
{
    public GameObject deathParticle;
    public int chance = 100;
    
    private bool isQuitting = false;

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (next.name == "Main Menu")
        {
            // Scene1 has been removed
            isQuitting = true;
        }

        Debug.Log("Scenes: " + currentName + ", " + next.name);
    }

    public void OnDestroy(){
        
        if (!isQuitting && Random.Range(1, 100) <= chance)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
        }
    }
}