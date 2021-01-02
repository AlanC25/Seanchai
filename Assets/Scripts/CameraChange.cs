using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject thirdPersonCam;
    public GameObject firstPersonCam;
    public int camMode;
    

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.isRoaming == true)
        {
            camMode = 1;
           
        }
        else
        {
            camMode = 0;
        }

        StartCoroutine(CamChange());
        
    }

    IEnumerator CamChange()
            {
                yield return new WaitForSeconds(0.01f);
                if (camMode == 0)
                {
                    thirdPersonCam.SetActive(true);
                    firstPersonCam.SetActive(false);
                }

                if (camMode == 1)
                {
                    firstPersonCam.SetActive(true);
                    thirdPersonCam.SetActive(false);
                }
            }
        }
        
    

