using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterTime : MonoBehaviour
{
    public float timeBeforeDeath;
    void Start()
    {
        Invoke("death",timeBeforeDeath);
    }

    // Update is called once per frame
    void death()
    {
        Destroy(gameObject);
    }
}
