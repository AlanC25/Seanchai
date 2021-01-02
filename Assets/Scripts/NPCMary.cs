using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMary : MonoBehaviour
{
    public String npcName;
    public DialogueSystem dialogueSystem;
    public List<String> npcConvo = new List<string>();
    public GameObject startSpeakingPanel;
    public bool isInRange;
    public static bool isInConvo;
    public Animator anim;
    public Transform player;
    private float animBlend;
    public GameObject maryGraphic;
    public GameObject maryGraphicAnim;
    private void Start()
    {
        startSpeakingPanel.SetActive(false);
        isInRange = false;
        isInConvo = false;
    }

    private void Awake()
    {
        maryGraphic.SetActive(true);
        maryGraphicAnim.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            startSpeakingPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
        startSpeakingPanel.SetActive(false);
    }

    private void Update()
    {
        //transform.LookAt(player);
        if (isInRange & Input.GetKeyDown(KeyCode.Space))
        {
            dialogueSystem.StartDialogue(npcName, npcConvo);
            startSpeakingPanel.SetActive(false);
            isInConvo = true;
            isInRange = false;
            maryGraphic.SetActive(false);
            maryGraphicAnim.SetActive(true);
            
        }

        if (dialogueSystem.inConvoAnim)
        {
            //animate
        }
        //else anim.SetFloat("Talking", 0);
    }
}
