using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CausewayOutroOneDirector : MonoBehaviour
{
    public GameObject fadeToBlack;
    public GameObject evilLaugh;
    private void Start()
    {
        StartCoroutine(Direction());
    }

    IEnumerator Direction()
    {
        evilLaugh.SetActive(false);
        yield return new WaitForSeconds(10);
        evilLaugh.SetActive(true);
        yield return new WaitForSeconds(2);
        fadeToBlack.SetActive(true);
        yield return new WaitForSeconds(2.7f);
        SceneManager.LoadScene("CausewayOutroPartTwo");
    }
}
