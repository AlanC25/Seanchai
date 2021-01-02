using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public static bool isRoaming;
    public float speed;

    public Animator anim;
    public DialogueSystem dialogueSystem;
    private float walkAnimBlend;

    public Transform player;

    public AudioSource footSteps;

    public float footStepVolume;
    // Start is called before the first frame update
    void Start()
    {
        isRoaming = true;
        anim.speed = 1.5f;
        footSteps.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRoaming == false /*|| dialogueSystem.isTalking*/)
        {
            Cursor.lockState = CursorLockMode.None;
            anim.SetFloat("Walk", 0);
            footSteps.volume = 0;
        }
        else if(isRoaming /*& !dialogueSystem.isTalking*/)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Move();
            
            //animations:

            if (Input.GetKey(KeyCode.W))
            {
                walkAnimBlend = Mathf.Lerp(walkAnimBlend, 1f, 10 * Time.deltaTime);
                anim.SetFloat("Walk", walkAnimBlend);
                footSteps.volume = footStepVolume;
            }
            else footSteps.volume = 0;
            
            if (Input.GetKey(KeyCode.A))
            {
                walkAnimBlend = Mathf.Lerp(walkAnimBlend, 1f,  10 * Time.deltaTime);
                anim.SetFloat("Walk", walkAnimBlend);
                footSteps.volume = footStepVolume;
            }
            if (Input.GetKey(KeyCode.D))
            {
                walkAnimBlend = Mathf.Lerp(walkAnimBlend, 1f,  10 * Time.deltaTime);
                anim.SetFloat("Walk", walkAnimBlend);
                footSteps.volume = footStepVolume;
            }
            if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.D))
            {
                walkAnimBlend = Mathf.Lerp(walkAnimBlend, 1f,  10 * Time.deltaTime);
                anim.SetFloat("Walk", walkAnimBlend);
            }
            if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.A))
            {
                walkAnimBlend = Mathf.Lerp(walkAnimBlend, 1f,  10 * Time.deltaTime);
                anim.SetFloat("Walk", walkAnimBlend);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                player.transform.Rotate(0,-30,0);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                player.transform.Rotate(0,30,0);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                player.transform.Rotate(0,30,0);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                player.transform.Rotate(0,-30,0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                anim.speed = 0.9f;
                anim.SetFloat("Walk", 1);
            }
            else anim.speed = 1.5f;
            
            if (!Input.GetKey(KeyCode.W) & !Input.GetKey(KeyCode.A) & !Input.GetKey(KeyCode.D) & !Input.GetKey(KeyCode.S))
            {
                anim.SetFloat("Walk", 0);
            }
        } 
        
    }

    void Move()
    {
       
             float hor = Input.GetAxis("Horizontal");
             float ver = Input.GetAxis("Vertical");
             Vector3 movement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
             transform.Translate(movement, Space.Self);
        
       
    }
}
