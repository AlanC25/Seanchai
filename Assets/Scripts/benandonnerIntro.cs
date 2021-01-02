using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class benandonnerIntro : MonoBehaviour
{
    private Animator anim;

    private float animBlend = 0;

    private bool canStretch = false;

    public GameObject fadeToBlack;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(BenStandUp());
    }

    private void Update()
    {
        if (canStretch)
        {
            StartStretching();
        }
    }

    IEnumerator BenStandUp()
    {
        yield return new WaitForSeconds(6);
        anim.enabled = true;
        yield return new WaitForSeconds(5);
        canStretch = true;
        yield return new WaitForSeconds(4);
        fadeToBlack.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("CausewayIntroPartThree");
    }

    void StartStretching()
    {
        if (animBlend < 1)
        {
            animBlend += 0.02f;
            anim.SetFloat("Stretch", animBlend);
        }
    }
}
