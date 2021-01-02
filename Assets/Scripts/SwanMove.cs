using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwanMove : MonoBehaviour
{
    private float Speed = 0.35f;
    private float BobbleFactor = 0.25f;
    private bool UpDown = true;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
        if(UpDown == true)
        {
            transform.Translate(Vector3.forward * BobbleFactor * Time.deltaTime);
            UpDown = false;
        }
        else if(UpDown != true)
        {
            transform.Translate(Vector3.back * BobbleFactor * Time.deltaTime);
            UpDown = true;
        }
    }
}
