using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class CausewayOutroTwoDirector : MonoBehaviour
{
    public GameObject ben;

    public GameObject fadeToBlack;
    public GameObject outroNar;
    private GameObject music;
    public GameObject babyNoises;

    public AudioMixer intenseMusic;
    private void Start()
    {
        StartCoroutine(BabyNoises());
        DontDestroyOnLoad(outroNar);
        DontDestroyOnLoad(this);
        ben.SetActive(false);
        music = GameObject.FindWithTag("musicSource");
        StartCoroutine(BenArrive());
    }

    IEnumerator BenArrive()
    {
        yield return new WaitForSeconds(11);
        ben.SetActive(true);
        yield return new WaitForSeconds(11);
        fadeToBlack.SetActive(true);
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("Roam Area No Inventory");
        Destroy(music);
        yield return new WaitForSeconds(1);
        displayScores.OpenScreen(); //show score screen - put this on outro skip button.
        outroNar.SetActive(true);
        yield return new WaitForSeconds(15);
        //ThirdPersonCharacterController.isRoaming = true;
        DialogueSystem.isTalking = false;
        Destroy(outroNar);
        Destroy(this);
        
    }

    IEnumerator BabyNoises()
    {
        babyNoises.SetActive(false);
        yield return new WaitForSeconds(12);
        babyNoises.SetActive(true);
    }
}
