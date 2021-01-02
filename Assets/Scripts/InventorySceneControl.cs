using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventorySceneControl : MonoBehaviour
{
    public GameObject canvas;
    public GameObject tripleSpiral;
    public GameObject stoneOfFail;
    public GameObject lughsSpear;
    public GameObject nuadasSword;
    public GameObject cauldron;
    public GameObject Player;
    public GameObject shamRock;
    public GameObject referee;
    public GameObject dialogueSystemSeamus;
    public GameObject dialogueSystemMary;
    public GameObject seamus;
    public GameObject mary;
    public GameObject pauseMenu;
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(tripleSpiral);
        DontDestroyOnLoad(stoneOfFail);
        DontDestroyOnLoad(lughsSpear);
        DontDestroyOnLoad(nuadasSword);
        DontDestroyOnLoad(cauldron);
        DontDestroyOnLoad(Player);
        DontDestroyOnLoad(shamRock);
        DontDestroyOnLoad(referee);
        DontDestroyOnLoad(seamus);
        DontDestroyOnLoad(mary);
        DontDestroyOnLoad(dialogueSystemMary);
        DontDestroyOnLoad(dialogueSystemSeamus);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Roam Area Take Two") || 
            SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Roam Area No Inventory"))
        {
            Player.SetActive(true);
            pauseMenu.SetActive(true);
        }
        else
        {
            Player.SetActive(false);
            pauseMenu.SetActive(false);
        }
    }
}
