using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickUp : MonoBehaviour
{
    public Transform theDest;
    public Animation inspectionWindow;
    public GameObject inspectionPanel;
    public Text inspectionText;
    
    void OnMouseDown()
    {
        InspectObject();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Destination").transform;
        PlayerMovement.isRoaming = false;

    }

    void OnMouseUp()
    {
        PlayerMovement.isRoaming = false;
        GetComponent<Rigidbody>().useGravity = false;
    }

    void InspectObject()
    {
        inspectionPanel.transform.localScale = Vector3.one;
        inspectionWindow.Play();
        Debug.Log("Playing Animation");
    }

    public void AddToInventory()
    {
        Destroy(gameObject);
        inspectionPanel.transform.localScale = Vector3.zero;
        PlayerMovement.isRoaming = true;
    }
}
