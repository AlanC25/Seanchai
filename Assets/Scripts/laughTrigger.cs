using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laughTrigger : MonoBehaviour
{
    public GameObject roar;

    private void Start()
    {
        roar.SetActive(false);
        StartCoroutine(Roar());
    }

    IEnumerator Roar()
    {
        yield return new WaitForSeconds(11);
        roar.SetActive(true);
    }
}
