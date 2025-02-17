using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    private float x;
    private float z;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      x = Input.GetAxisRaw("Horizontal");
      z = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
            rb.velocity = new Vector3(x * speed, rb.velocity.y, z * speed);

        if (rb.position.y < -20)
        {
            rb.position = new Vector3(0, 5, 0); 
        }
    }

}
