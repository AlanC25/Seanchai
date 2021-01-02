using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainIntroDirector : MonoBehaviour
{
    public ThirdPersonCharacterController thirdPersonCharacterController;
    // Start is called before the first frame update
    void Start()
    {
        thirdPersonCharacterController.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            thirdPersonCharacterController.enabled = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
