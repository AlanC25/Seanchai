﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouse : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed;
 

   
    // Update is called once per frame
    void Update ()
    {
       // if (Input.GetMouseButton(1)) {
            mousePosition = Input.mousePosition;
            //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
       // }
 
    }
}
