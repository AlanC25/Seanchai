using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    private float timeLeft = 301;
    private bool timerRunning = false;
    public GameObject timeLeftUI;
    public string sceneNameToLoad;

    void Start()
    {
        timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning == true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft >= 0)
            {
                string minutes = Mathf.Floor(timeLeft / 60).ToString("00");
                string seconds = Mathf.Floor(timeLeft % 60).ToString("00");

                timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + minutes + ":" + seconds);
            }
        }
        if (timeLeft <= -3.1f)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
