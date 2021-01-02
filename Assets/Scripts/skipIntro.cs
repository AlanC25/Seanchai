using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skipIntro : MonoBehaviour
{
    public void SkipIntroButton()
    {
        SceneManager.LoadScene("TheGiantsCauseway");
        CausewayReferee.timer = 0;
        CausewayReferee.killCount = 0;
    }
}
