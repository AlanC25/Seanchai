using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giantJump : MonoBehaviour
{
    public float jumpHeight;
    public bool isGrounded;
 
    private Rigidbody rb;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
 
    void Update()
    { 
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpHeight);
            Debug.Log("jumping");
        }
    }
 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
 
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    
}
