using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class congratulator : MonoBehaviour
{
    public GameObject congrats;
    public Text time;
    public Text fastestTime;

    private void Awake()
    {
        congrats.SetActive(false);
    }

    private void Update()
    {
        if (time.text == fastestTime.text)
        {
            congrats.SetActive(true);
        }
        else congrats.SetActive(false);
    }
}
