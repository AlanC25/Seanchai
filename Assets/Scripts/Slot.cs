using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public int ID;
    
    public bool empty;
    public Sprite icon;
    public GameObject item; //object contained in the inventory slot
    public Transform slotIconObject;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        UseItem();
    }

    private void Start()
    {
        slotIconObject = transform.GetChild(0);
    }

    public void UpdateSlot()
    {
        slotIconObject.GetComponent<Image>().sprite = icon;
    }

    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();
    }
    
}
