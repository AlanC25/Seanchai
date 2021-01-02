using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GiantAnimations : MonoBehaviour
{
    
    private Animator anim;
    private float animationBlend;
    private bool isAttacking;
    public CharacterController controller;
    public GameObject weapon;
    private bool attackOver = true;
    public static bool deathStarted;
    public GameObject youDied;
    public GameObject youDiedContents;
    public GameObject attackSound;
    public GameObject deathSound;
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0.5f;
        weapon.SetActive(false);
        attackSound.SetActive(false);
        deathSound.SetActive(false);
        deathStarted = false;
    }

    private void Update()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        if (Input.GetKeyDown(KeyCode.H) && attackOver)
        {
            StartCoroutine(Attack());
        }

        if (anim.GetBool("isAttack") == false)
        {
            if (!controller.isGrounded)
            {
                animationBlend = Mathf.Lerp(animationBlend, 2f,  50 * Time.deltaTime);
                anim.SetFloat("Blend", animationBlend);
            }
            if (controller.isGrounded)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    animationBlend = Mathf.Lerp(animationBlend, 1f,  50 * Time.deltaTime);
                    anim.SetFloat("Blend", animationBlend);
                }
    
                if (!Input.GetKey(KeyCode.W))
                {
                    animationBlend = Mathf.Lerp(animationBlend, 0,  50 * Time.deltaTime);
                    anim.SetFloat("Blend", animationBlend);
                }
            }
        }

        if (GiantMovement.health <= 0)
        {
            StartCoroutine(Die());
        }
        
    }

    IEnumerator Attack()
    {
        attackSound.SetActive(true);
        attackOver = false;
        anim.speed = 1;
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("isAttack", false);
        //yield return new WaitForSeconds(0.2f);
        weapon.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        weapon.SetActive(false);
        yield return new WaitForSeconds(0.45f);
        attackSound.SetActive(false);
        anim.speed = 0.5f;
        attackOver = true;
    }

    IEnumerator Die()
    {
        deathStarted = true;
        anim.SetBool("isDead", true);
        deathSound.SetActive(true);
        youDied.SetActive(true);
        yield return new WaitForSeconds(1);
        youDiedContents.SetActive(true);
        GiantMovement.health = 100;
        //deathStarted = false;

    }
    
}
