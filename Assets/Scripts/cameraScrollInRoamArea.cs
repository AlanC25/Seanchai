using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScrollInRoamArea : MonoBehaviour
{
    public Animation camAnim;
    public GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && cameraScrollTriggerRoamArea.hasLeftCabin == true)
        {
            camAnim.Rewind();
            cameraScrollTriggerRoamArea.hasLeftCabin = false;
            door.SetActive(true);
        }
    }
}
