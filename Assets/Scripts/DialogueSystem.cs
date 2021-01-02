using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text npcNameText;
    public Text dialogueText;

    private List<String> conversation;
    private int convoIndex;

    public GameObject nextButton;
    public GameObject disabledNextButton;
    public GameObject yesButton;
    public GameObject noButton;
    public GameObject disabledYes;
    public GameObject disabledNo;

    public static bool isTalking = false;
    public bool inConvoAnim = false;

    public GameObject script1;
    public GameObject script2;
    public GameObject script3;

    // Start is called before the first frame update
    void Start()
    {
        convoIndex = 0;
        dialoguePanel.SetActive(false);
        nextButton.SetActive(true);
        yesButton.SetActive(false);
        disabledYes.SetActive(false);
        disabledNo.SetActive(false);
        noButton.SetActive(false);
        isTalking = false;
        StopDialogue(); //test
    }

    private void Awake()
    {
        script1 = this.transform.GetChild(0).gameObject;
        script2 = this.transform.GetChild(1).gameObject;
        script3 = this.transform.GetChild(2).gameObject;
    }


    public void StartDialogue(string npcName, List<String> convo)        //FOR SEAMUS 
    {
        inConvoAnim = true;
        ThirdPersonCharacterController.isRoaming = false;
        isTalking = true;
        npcNameText.text = npcName;
        conversation = new List<string>(convo);
        dialoguePanel.SetActive(true);
        convoIndex = 0;
        ShowText();
        nextButton.SetActive(true);
        disabledNextButton.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        disabledYes.SetActive(false);
        disabledNo.SetActive(false);
        script1.SetActive(true);
        
        //First                           //COS OF THIS
    }
    
    public void StopDialogue()
    {
        inConvoAnim = false;
        ThirdPersonCharacterController.isRoaming = true;
        dialoguePanel.SetActive(false);
        isTalking = false;
        NPC.isInConvo = false;
        NPCMary.isInConvo = false;
        isTalking = false;
    }
    public void ShowText()
    {
        dialogueText.text = conversation[convoIndex];
    }

    public void Next() // for next button
    {
        disabledYes.SetActive(false);
        disabledNo.SetActive(false);
        if (convoIndex == 0)
        {
            script1.SetActive(false);
            script3.SetActive(false); // must set false for it to be played a second time.
            script2.SetActive(true); //second
        }
        if (convoIndex == 1) // question
        {
            nextButton.SetActive(false);
            yesButton.SetActive(true);
            noButton.SetActive(true);
            script2.SetActive(false);
            script3.SetActive(true); //third
        }

        if (convoIndex != 1)
        {
            nextButton.SetActive(true);
            yesButton.SetActive(false);
            noButton.SetActive(false);
        
        }
    
        if (convoIndex < conversation.Count - 1)
        {
            convoIndex += 1;
            ShowText();
        }
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("CausewayIntro");
        script3.SetActive(false);
        dialoguePanel.SetActive(false);
        isTalking = false;
    }

    public void StartDreamOfOengus()
    {
        SceneManager.LoadScene("1.Chapter1");
        dialoguePanel.SetActive(false);
        isTalking = false;
    }
}
