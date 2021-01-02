using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipOutro : MonoBehaviour
{
    public void SkipOutroButton()
    {
        displayScores.OpenScreen();
        SceneManager.LoadScene("Roam Area No Inventory");
        
    }
}
