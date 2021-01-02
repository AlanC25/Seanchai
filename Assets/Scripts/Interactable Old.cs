
using System;
using UnityEngine;
  //replacing transform with this is for interacting with objects from a certain angle/position
   //making another game object and putting it in the interaction transform of the script component will set the position for interactin
   //we want to know if the player focused is close enough to interact
public class Interactable : MonoBehaviour
{
   //private Rigidbody rb;
   public float radius= 3f; 
   //public Transform interactionTransform;
   bool isFocus = false; 
   bool isOpen = false;
   Transform player;
   //public Transform doorTransform;
   
   
   //private Interactable focus;
    

   bool hasInteracted = false;

   public virtual void Interact()
   {
       Debug.Log("Interacting with " + transform.name);
   }



   void Update()
   {
       if (isFocus && !hasInteracted)
       {
           float distance = Vector3.Distance(player.position, transform.position);
           if (distance <= radius)
           {
               Debug.Log("Interacting, Well Done!");
               hasInteracted = true;
           }
       }
   }

   public void OnFocused ( Transform playerTransform)
   {
       isFocus = true; 
       player = playerTransform;
       hasInteracted = false;
       Debug.Log("Focusing...");
   }
   
   public void DeFocused ()
   {
       isFocus = false; 
       player = null;
       hasInteracted = false;
       Debug.Log("De-Focusing...");
   }

   void OnDrawGizmosSelected ()
   {
       Gizmos.color = Color.yellow;
       Gizmos.DrawWireSphere(transform.position, radius);
       
   }
}
