using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class causewayDirector : MonoBehaviour
{
    private GameObject musicSource;
    private GameObject referee;
    public GameObject wasd;

    private void Start()
    {
        musicSource = GameObject.FindWithTag("musicSource");
        referee = GameObject.Find("referee");
        wasd.SetActive(true);
        StartCoroutine(wasdInstructs());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("TheGiantsCauseway");
        CausewayReferee.killCount = 0;
        CausewayReferee.timer = 0;
    }
    
    public void ReturnToRoamArea()
    {
        ThirdPersonCharacterController.isRoaming = true;
        DialogueSystem.isTalking = false;
        SceneManager.LoadScene("Roam Area No Inventory");
        Destroy(musicSource);
    }

    IEnumerator wasdInstructs()
    {
        yield return new WaitForSeconds(3);
        wasd.SetActive(false);
    }
}
