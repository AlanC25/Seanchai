using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class CausewayPauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioSource footsteps;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            footsteps.enabled = false;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        footsteps.enabled = true;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("TheGiantsCauseway");
        GiantMovement.health = 100;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Roam Area No Inventory");
    }
}
