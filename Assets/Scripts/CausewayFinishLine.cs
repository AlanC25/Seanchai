using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CausewayFinishLine : MonoBehaviour
{
    public GameObject fadeToBlack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StartCoroutine(PassedGame());
            CausewayReferee.EndGame();
        }
    }

    IEnumerator PassedGame()
    {
        fadeToBlack.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("CausewayOutroPartOne");
    }
}
