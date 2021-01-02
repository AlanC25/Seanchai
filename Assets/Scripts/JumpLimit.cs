using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLimit : MonoBehaviour
{
    public static bool canFall;
    public float jumpHeight;
    private void Update()
    {
        if (!CheckJump())
        {
            canFall = true;
        }

        if (groundCheck.isGrounded)
        {
            canFall = false;
        }
        
        
        Debug.Log(canFall);
        
    }

    bool CheckJump()
    {
        return Physics.Raycast(transform.position, Vector3.down, jumpHeight);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            canFall = true;
            Debug.Log("left the ground");
        }
        
    }
}
