using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
public class CountTime : MonoBehaviour
{
    private bool timerRunning = false;
    Text txt;

    void Awake()
    {
        txt = GetComponent<Text>();
    }

    void Start()
    {
        timerRunning = true;
    }

    void Update()
    {
        if (timerRunning == true)
        { 
            string minutes = Mathf.Floor(Time.timeSinceLevelLoad / 60).ToString("00");
            string seconds = Mathf.Floor(Time.timeSinceLevelLoad % 60).ToString("00");

            txt.text = ("Time: " + minutes + ":" + seconds);
        }
    }
}
