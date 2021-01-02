using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantMovement : MonoBehaviour
{
    [SerializeField] private float speed = 50;

    [SerializeField] private float gravity = 0.1f;

    [SerializeField] private float jumpSpeed = 3.5f;

    [SerializeField] private float doubleJumpMultiplier = 0.5f;

    private bool canDoubleJump = false;
    private float rot;
    public float rotSpeed;

    private float directionY;

    private CharacterController controller;
    private Rigidbody rb;

    private bool gotHit;

    public static float health;

    public HealthBar healthBar;

    public GameObject jumpSound;
    public GameObject jumpSoundTwo;

    public AudioSource footsteps;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        health = 100;
        healthBar.SetMaxHealth(100);
        jumpSound.SetActive(false);
        jumpSoundTwo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotSpeed, 0 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotSpeed, 0 * Time.deltaTime);
        }

        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(0, 0, vertical);

        if (controller.isGrounded)
        {
            //jumpSound.SetActive(false);
            canDoubleJump = true;

            if (Input.GetButtonDown("Jump"))
            {
                directionY = jumpSpeed;
                jumpSound.SetActive(false);
                jumpSound.SetActive(true);
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && canDoubleJump)
            {
                directionY = jumpSpeed * doubleJumpMultiplier;
                jumpSoundTwo.SetActive(false);
                jumpSoundTwo.SetActive(true);
                canDoubleJump = false;
            }
        }

        if (Input.GetKey(KeyCode.H))
        {
            //direction = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.W) && controller.isGrounded)
        {
            footsteps.volume = 0.5f;
        }
        else footsteps.volume = 0;

        directionY -= gravity * Time.deltaTime;

        direction.y = directionY;

        direction = transform.TransformDirection(direction);

        controller.Move(direction * speed * Time.deltaTime);
        
        healthBar.SetHealth(health);
    }
}
