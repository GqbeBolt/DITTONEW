using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public GameObject[] enemies;
    private int randIndex;
    
    void Start()
    {
        randIndex = (int)Random.Range(0, enemies.Length);
        Instantiate(enemies[randIndex], transform.position,Quaternion.identity);
    }
}
