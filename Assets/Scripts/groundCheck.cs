using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public float distanceToGround = 1.5f;
    public static bool isGrounded;
    private void Update()
    {
        //CheckGrounded();
                
        if (CheckGrounded())
        {
            isGrounded = true;
        }

        if (!CheckGrounded())
        {
            isGrounded = false;
        }
        //Debug.Log(isGrounded);
    }

    bool CheckGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround);
    }
}
