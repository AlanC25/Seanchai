using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScriptFinal : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;
    bool finalCount = true;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(finalCount == true)
        {
            score.text = "Score: " + ScoreScript.scoreValue;
            finalCount = false;
        }
    }
}
