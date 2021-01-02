using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // SYKOO INVENTROY TUTPORIAL 
    public static bool inventoryEnabled;
    public GameObject inventory;
    private int allSlots = 8;
    private int enabledSlots;
    private GameObject[] slot;
    public GameObject slotHolder;
    public Text youPickedUp;
    public GameObject pickUpInstructs;
    public GameObject openPage;
    public GameObject closePage; //need to dont destroy??
    public GameObject pickUpSound;
    public GameObject clickerSound;
    public float itemCount = 0;

    private void Start()
    {
        pickUpSound.SetActive(false);
        openPage.SetActive(false);
        closePage.SetActive(false);
        inventory.SetActive(false);
        pickUpInstructs.SetActive(false);
        allSlots = 8;
        slot = new GameObject[allSlots];
        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true; 
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!DialogueSystem.isTalking)
            {
                inventoryEnabled = !inventoryEnabled;
                if (inventoryEnabled)
                {
                    openPage.SetActive(false);
                    inventory.SetActive(true);
                    //open
                    openPage.SetActive(true);
                    ThirdPersonCharacterController.isRoaming = false;
                    pickUpInstructs.SetActive(false); //for no overlapping
                    youPickedUp.text = null;
                }
                else
                {
                    closePage.SetActive(false);
                    inventory.SetActive(false);
                    closePage.SetActive(true);
                    ThirdPersonCharacterController.isRoaming = true;
                }
            }
        }

        if (inventoryEnabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickerSound.SetActive(false);
                clickerSound.SetActive(true);
            }
        }

        if (itemCount == 6)
        {
            CompleteGame.invIsComplete = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            pickUpSound.SetActive(false);
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();
            AddItem(itemPickedUp, item.ID, item.description, item.icon);
            pickUpSound.SetActive(true);
        }
        
    }

    void AddItem(GameObject itemObject, int itemID, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            itemCount += 1;
            if (slot[i].GetComponent<Slot>().empty)
            {
                //add item to slot
                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().ID = itemID;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);
                
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;

                StartCoroutine(PickingUp(itemObject));
                return;
            }
        }
    }

    IEnumerator PickingUp(GameObject itemName)
    {
        pickUpInstructs.SetActive(true);
        youPickedUp.text = ("You found " + (itemName.name).ToString());
        yield return new WaitForSeconds(3);
        youPickedUp.text = null;
        pickUpInstructs.SetActive(false);
       
    }
    


    
}
