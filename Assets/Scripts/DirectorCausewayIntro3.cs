using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirectorCausewayIntro3 : MonoBehaviour
{
    public GameObject controls;

    public GameObject controlsText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Director());
    }
    
    IEnumerator Director()
    {
        yield return new WaitForSeconds(15);
        controls.SetActive(true);
        yield return new WaitForSeconds(2f);  
        controlsText.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("TheGiantsCauseway");
        CausewayReferee.killCount = 0;
        CausewayReferee.timer = 0;
    }
}
