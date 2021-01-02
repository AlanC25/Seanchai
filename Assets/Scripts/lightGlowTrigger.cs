using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightGlowTrigger : MonoBehaviour
{
   public Animation lightGlowAnim;

   private void Start()
   {
      lightGlowAnim.wrapMode = WrapMode.Loop;
      lightGlowAnim.Play();
   }
}
