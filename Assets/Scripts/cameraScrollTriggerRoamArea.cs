using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScrollTriggerRoamArea : MonoBehaviour
{
    public static bool hasLeftCabin = false;
    public Animation camAnim;
    public GameObject pickUpText; //for unhiding after intro
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasLeftCabin == false)
        {
            camAnim.Play();
            hasLeftCabin = true;
            pickUpText.SetActive(true);
        }
    }
}
