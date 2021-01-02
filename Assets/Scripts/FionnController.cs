using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FionnController : MonoBehaviour
{
    private float playerSpeed = 8f;
    public int playerJumpPower = 2000;
    private float moveX;
    public bool isGrounded;
    private float distanceToBottom = 1.3f;

    public AudioClip walk, jump, coin, whimper;

    public GameObject Fionn;
    private PlayerHealth FionnHealth;

    public Rigidbody2D myRigidbody;
    public float FallingThreshold = -0.1f;
    public bool falling = false;

    // Update is called once per frame
    void Update()
    {
        if (myRigidbody.velocity.y < FallingThreshold)
        {
            falling = true;
        }
        else
        {
            falling = false;
        }

        PlayerMove();
    }

    void PlayerMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
        //Animation
        if (moveX != 0)
        {
            GetComponent<Animator>().SetBool("isRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isRunning", false);
        }

        //Player Direction
        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(jump);

        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            if (falling == true)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(whimper);

                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
                ScoreScript.scoreValue += 200;

                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
                collision.gameObject.GetComponent<Rigidbody2D>().rotation = -120;
                collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                collision.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                collision.gameObject.GetComponent<EnemyMove>().enabled = false;
            }
            else
            {
                FionnHealth = Fionn.GetComponent<PlayerHealth>();
                FionnHealth.Die();
            }
        }
        else if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "obstacles")
        {
            isGrounded = true;
        }
    }
}

