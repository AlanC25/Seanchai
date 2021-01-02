using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamAreaPauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioSource footsteps;

    private void Awake()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            footsteps.enabled = false;
            pauseMenu.SetActive(true);
            ThirdPersonCharacterController.isRoaming = false;
            Time.timeScale = 0;
            
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        footsteps.enabled = true;
        ThirdPersonCharacterController.isRoaming = true;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        //SceneManager.LoadScene("TheGiantsCauseway");
    }

    public void Quit()
    {
        //SceneManager.LoadScene("Roam Area No Inventory");
    }
}
