using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    void Start()
    {
        Invoke("Erase", 6f);
    }

    
    void Update()
    {
        
    }

    public void Erase()
    {
        Destroy(gameObject);
    }
}
