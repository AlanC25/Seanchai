using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    public LayerMask movementMask;
    public Transform doorTransform;
    Camera cam;
    private Rigidbody rb;
   
    

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Left MOUSE CLICK
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);          //shoots a ray towards the mouse position 
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))           //If the ray hits something the following will be excecuted 
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
        else if (Input.GetMouseButtonDown(1)) //Right MOUSE CLICK
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);          //shoots a ray towards the mouse position 
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))           //If the ray hits something the following will be excecuted 
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    RemoveFocus();
                }
            }
        }


    }
    
    void SetFocus(Interactable newFocus)
    {
        //if (newFocus != focus)
       // {
            
                Debug.Log("Focused");
                focus = newFocus;
                newFocus.OnFocused(transform);
       // }
        PlayerMovement.isRoaming = false;
        
        
    }
    

    void RemoveFocus()
    {
        if (focus != null)
        {
            Debug.Log("Unfocused");
            focus.DeFocused(); 
            focus = null;
        }
        PlayerMovement.isRoaming = true;
    }
    
}

