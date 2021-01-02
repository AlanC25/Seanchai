using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class displayScores : MonoBehaviour
{
    private static GameObject scores;
    private static GameObject hiScore;
    private static Text killText;
    private static Text timeText;
    private static Text hiScoreText;
    public static GameObject hiScoreIcon;
    public static bool isFastestTime;

    private bool isFinishedLevel;
    private void Awake()
    {
        scores = this.transform.GetChild(0).gameObject;
        hiScoreIcon = scores.transform.GetChild(3).gameObject;
        hiScore = scores.transform.GetChild(2).gameObject;
        killText = scores.transform.GetChild(1).GetComponentInChildren<Text>();
        timeText = scores.transform.GetChild(0).GetComponentInChildren<Text>();
        hiScoreText = hiScore.GetComponentInChildren<Text>();
    }
    
    public static void DisplayScore(float time, float kills, float fastestTime)
    {
        /*if (isHiScore)
        {
            Debug.Log("high score");
            isFastestTime = true;
            hiScoreIcon.SetActive(true);
        }
        else
        {
            Debug.Log("no high score");
            isFastestTime = false; //bool for showing hi score feedback
            hiScoreIcon.SetActive(false);
        }*/
        killText.text = kills.ToString();
        timeText.text = time.ToString("F0");
        hiScoreText.text = fastestTime.ToString("F0");
    }

    public static void OpenScreen()
    {
        scores.SetActive(true);
        ThirdPersonCharacterController.isRoaming = false;
        
    }

    public void CloseScreen()
    {
        scores.SetActive(false);
        hiScoreIcon.SetActive(false);
        ThirdPersonCharacterController.isRoaming = true;
        DialogueSystem.isTalking = false;
        CompleteGame.causeWayIsComplete = true;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("CausewayIntro");
        scores.SetActive(false);
        hiScoreIcon.SetActive(false);
        CausewayReferee.killCount = 0;
    }
}
