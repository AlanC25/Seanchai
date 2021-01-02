using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CausewayMusicControl : MonoBehaviour
{

    private AudioSource intenseMusic;
    private float volumeFade;
    private void Start()
    {
        intenseMusic = this.GetComponent<AudioSource>();
        intenseMusic.volume = 1;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Roam Area No Inventory"))
        {
           Destroy(this.gameObject);
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("CausewayOutroPartTwo"))
        {
            //volumeFade = Mathf.Lerp(1, 0, 100) * Time.deltaTime;
            //intenseMusic.volume = volumeFade;
            StartCoroutine(VolumeFade());
        }
    }

    IEnumerator VolumeFade()
    {
        yield return new WaitForSeconds(10);
        intenseMusic.volume -= 0.01f;
        yield return new WaitForSeconds(2);
        intenseMusic.volume -= 0.01f;
        yield return new WaitForSeconds(2);
        intenseMusic.volume -= 0.01f;
        yield return new WaitForSeconds(2);
        intenseMusic.volume -= 0.01f;
        yield return new WaitForSeconds(2);
        intenseMusic.volume -= 0.01f;

    }
}
