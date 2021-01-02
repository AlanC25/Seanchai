using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setActiveWASD : MonoBehaviour
{
    public GameObject wasd;

    private void Start()
    {
        wasd.SetActive(false);
        StartCoroutine(wasdShowAndHide());
    }

    IEnumerator wasdShowAndHide()
    {
        yield return new WaitForSeconds(2);
        wasd.SetActive(true);
        yield return new WaitForSeconds(3);
        wasd.SetActive(false);
    }
}
