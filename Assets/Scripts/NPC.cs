using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NPC : MonoBehaviour
{
    public String npcName;
    public DialogueSystem dialogueSystem;
    public List<String> npcConvo = new List<string>();
    public GameObject startSpeakingPanel;
    public bool isInRange;
    public static bool isInConvo;
    public Animator anim;
    private Transform player;
    private float animBlend;
    
    private void Start()
    {
        startSpeakingPanel.SetActive(false);
        isInRange = false;
        isInConvo = false;
        player = GameObject.FindWithTag("Player").transform;
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
        if (isInRange & Input.GetKeyDown(KeyCode.Space))
        {
            dialogueSystem.StartDialogue(npcName, npcConvo);
            startSpeakingPanel.SetActive(false);
            isInConvo = true;
            isInRange = false;
            Debug.Log("yo");
        }

        if (dialogueSystem.inConvoAnim)
        {
            animBlend = Mathf.Lerp(0, 1, 5) * Time.deltaTime;
            anim.SetFloat("Talking", animBlend);
        }
        else
        {
            animBlend = Mathf.Lerp(0, 1, 5) * Time.deltaTime;
            anim.SetFloat("Talking", animBlend);
            anim.SetFloat("Talking", 0);
        }
    }
}
