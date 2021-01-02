using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    [SerializeField] private Animator myAnimatorController;
    public void playFadeAnim()
    {
        myAnimatorController.Play("FadeOut");
    }
}
