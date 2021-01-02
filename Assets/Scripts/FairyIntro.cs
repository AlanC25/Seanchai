using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FairyIntro : MonoBehaviour
{
    public GameObject fairyDialoguePanel;
    public Text dialogue;

    private int convoIndex = 0;

    private bool hasOpenedInventory = false;
    private bool hasClosedInventory = false;

    public GameObject ScriptFairy1;
    public GameObject ScriptFairy2;
    public GameObject ScriptFairy3;
    public GameObject ScriptFairy4;

    public GameObject shamrock;

    public GameObject pickUpText;
    public Animation orbFlyAnim;
    public GameObject orb;
    public GameObject wasd;
    public GameObject fadeFromBlack;
    void Start()
    {
        StartCoroutine(OpenDelay());
        ScriptFairy1.SetActive(true);
        dialogue.text = "Press -E- to look at your Inventory.";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            fairyDialoguePanel.SetActive(false);
            if (convoIndex == 1)
            {
                Debug.Log("3");
                ScriptFairy2.SetActive(false);
                ScriptFairy3.SetActive(true);
                wasd.SetActive(true);
                StartCoroutine(HaveFun());
                hasClosedInventory = true;
                convoIndex = 2;
            }
            else if (convoIndex == 0)
            {
                Debug.Log("2");
                ScriptFairy1.SetActive(false);
                ScriptFairy2.SetActive(true);
                pickUpText.SetActive(false);
                shamrock.SetActive(true);
                hasOpenedInventory = true;
                convoIndex = 1;
            }
        }
    }

    IEnumerator OpenDelay()
    {
        yield return new WaitForSeconds(4.5f);
        fairyDialoguePanel.SetActive(true);
        Destroy(fadeFromBlack);
    }
    IEnumerator HaveFun()
    {
        orbFlyAnim.Play();
        yield return new WaitForSeconds(3);
        wasd.SetActive(false);
        yield return new WaitForSeconds(2);
        ScriptFairy4.SetActive(true);
        fairyDialoguePanel.SetActive(false);
        orb.SetActive(false);
    }
}
