using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenDirector : MonoBehaviour
{
    public GameObject logoStill;
    public GameObject logoMove;
    public GameObject logoStillTrans;
    public GameObject button;
    public GameObject fade;
    private void Start()
    {
        StartCoroutine(StartScreenDirection());
    }

    public void StartPlayingSeanchai()
    {
        SceneManager.LoadScene("Roam Area Take Two");
    }

    IEnumerator StartScreenDirection()
    {
        yield return new WaitForSeconds(6);
        fade.SetActive(false);
        logoStill.SetActive(false);
        logoMove.SetActive(true);
        button.SetActive(true);
        yield return new WaitForSeconds(2f);
        logoStillTrans.SetActive(true);
        logoMove.SetActive(false);
    }
}
