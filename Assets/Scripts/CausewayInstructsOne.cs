using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CausewayInstructsOne : MonoBehaviour
{
    public GameObject instructs;
    public Text instructsText;

    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Jump"))
        {
            instructsText.text = "Press -SPACE- to Jump";
        }
        else if (this.CompareTag("Attack"))
        {
            instructsText.text = "Press -H- to Attack";
        }
        else if (this.CompareTag("DoubleJump"))
        {
            instructsText.text = "Press -SPACE- while jumping to do a -DOUBLE JUMP-";
        }
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowInstructs());
        }
    }

    private IEnumerator ShowInstructs()
    {
        instructs.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        instructs.SetActive(false);
    }
    
    
}
