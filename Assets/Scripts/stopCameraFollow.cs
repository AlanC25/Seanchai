using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopCameraFollow : MonoBehaviour
{
    public GameObject camera;

    public GameObject splashSound;
    // Start is called before the first frame update
    void Start()
    {
        camera.transform.SetParent(transform);
        splashSound.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            camera.transform.SetParent(null);
            splashSound.SetActive(true);
            GiantMovement.health = 0;
        }
    }
}
