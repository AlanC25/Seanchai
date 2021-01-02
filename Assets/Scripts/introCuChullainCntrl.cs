using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introCuChullainCntrl : MonoBehaviour
{
    private Animator animator;

    private bool canShout = false;
    private float animBlend = 0;

    public GameObject fadeToBlack;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0.5f;
        StartCoroutine(EpicStandUp());
    }

    private void Update()
    {
        if (canShout)
        {
            StartShouting();
        }
    }

    IEnumerator EpicStandUp()
    {
        animator = GetComponent<Animator>();
        yield return new WaitForSeconds(6);
        animator.enabled = true;
        yield return new WaitForSeconds(4);
        canShout = true;
        yield return new WaitForSeconds(5);
        fadeToBlack.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("CausewayIntroPartTwo");

    }

    void StartShouting()
    {
        if (animBlend < 1)
        {
            animBlend += 0.02f;
            animator.SetFloat("Standing", animBlend);
        }
    }
}
