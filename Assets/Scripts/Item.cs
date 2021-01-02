using System;
using System.Collections;
using System.Collections.Generic;
//using Data.Util;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //public String type;
    public int ID;
    public String description;
    public Sprite icon;
    public bool pickedUp;
    
    
    [HideInInspector]
    public bool isUsing;
    
    [HideInInspector]
    public GameObject displayObject;

    [HideInInspector] 
    public GameObject itemManager;
    
    public bool playersObject;

    public void Start()
    {
        itemManager = GameObject.FindWithTag("ItemManager");
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            itemManager.transform.GetChild(0).gameObject.SetActive(false);
            itemManager.transform.GetChild(1).gameObject.SetActive(false);
            itemManager.transform.GetChild(2).gameObject.SetActive(false);
            itemManager.transform.GetChild(3).gameObject.SetActive(false);
            itemManager.transform.GetChild(4).gameObject.SetActive(false);
            itemManager.transform.GetChild(5).gameObject.SetActive(false);
        }
    }
    

    public void ItemUsage()
    {
        itemManager = GameObject.FindWithTag("ItemManager");
        int allItems = itemManager.transform.childCount;
        for (int i = 0; i < allItems; i++)
        {
            itemManager.transform.GetChild(i).gameObject.SetActive(false);
            if (itemManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
            {
                displayObject = itemManager.transform.GetChild(ID).gameObject;
                displayObject.SetActive(true);
                isUsing = true;
            }
        }
        
    }
}
