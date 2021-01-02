using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CausewayReferee : MonoBehaviour
{
    [HideInInspector] public static float killCount;
    [HideInInspector] public static float timer;
    [HideInInspector] public static float fastestTime;
    
    private static bool startCounting;

    public Text scoreDisplay;
    public Text killDisplay;
    
    private CausewayReferee causewayReferee;
    public GameObject causewayScoreInGame;
    
    private void Awake()
    {
        startCounting = true;
        timer = 0;
        killCount = 0;
    }

    private void Start()
    {
        startCounting = true;
        timer = 0;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("TheGiantsCauseway"))
        {
            startCounting = true;
            causewayScoreInGame.SetActive(true);
        }
        else
        {
            startCounting = false;
            causewayScoreInGame.SetActive(false);
        }
        
        if (startCounting)
        {
            timer += Time.deltaTime;
        }
        scoreDisplay.text = timer.ToString("F0");
        killDisplay.text = (killCount + "/20");
    }

    public static void EndGame() //logs high score and resets to 0
    {
        startCounting = false;
        if (timer <= fastestTime || fastestTime < 1)
        {
            fastestTime = timer;
            displayScores.DisplayScore(timer, killCount, fastestTime);
        }
        else displayScores.DisplayScore(timer, killCount, fastestTime);
    }

    public static void addKill()
    {
        killCount += 1;
    }
}
