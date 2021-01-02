using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class GiantController : MonoBehaviour
{
    public float speed;
    public float rotSpeed;
    public float jumpHeight;
    
    private float rot = 0f;
    public float gravity = -2000;
    
    private Vector3 moveDir = Vector3.zero;

    private CharacterController controller;
    private Animator anim;
    private Collider collider;
    private float animationBlend;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider>();

    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            moveDir = new Vector3(0, 0, 1);
            moveDir *= speed;
            if (!groundCheck.isGrounded)
            {
                moveDir.y = Time.deltaTime * gravity;
            }
        }

        if (!groundCheck.isGrounded)
            {
                moveDir.y = Time.deltaTime * gravity;
                
            }
                
            if (Input.GetKey(KeyCode.Space))
            {
                if (!JumpLimit.canFall)
                {
                     moveDir.y = jumpHeight;
                }

            }
            
            moveDir = transform.TransformDirection(moveDir);
            
        if (!Input.GetKey(KeyCode.W))
        {
            moveDir = new Vector3(0, 0, 0);
            if (Input.GetKey(KeyCode.Space))
            {
                if (!JumpLimit.canFall)
                {
                     moveDir.y = jumpHeight;
                }

                if (JumpLimit.canFall)
                {
                    moveDir.y = Time.deltaTime * gravity;
                }
            }
            if (!Input.GetKey(KeyCode.Space))
            {
                moveDir.y = Time.deltaTime * gravity;
            }
            moveDir = transform.TransformDirection(moveDir);

            if (JumpLimit.canFall)
            {
                moveDir.y = Time.deltaTime * gravity;
            }
        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0,rot,0);
        controller.Move(moveDir * Time.deltaTime);
}
}
