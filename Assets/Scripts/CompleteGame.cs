using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteGame : MonoBehaviour
{
    public static bool causeWayIsComplete = false; //set to true when closing high score panel
    public static bool oengusIsComplete = false; // set to true on return to hub button
    public static bool salmonIsComplete = false; 
    public static bool invIsComplete = false; // set to true in Inventory script in Player

    public GameObject completeGamePanel;
    public GameObject flash;

    void Start()
    {
        completeGamePanel.SetActive(false);
    }
    
    void Update()
    {
        if (causeWayIsComplete && oengusIsComplete /*&& salmonIsComplete*/ && invIsComplete)
        {
            Debug.Log("You Win");
            completeGamePanel.SetActive(true);
            ThirdPersonCharacterController.isRoaming = false;
            DialogueSystem.isTalking = true;
            StartCoroutine(DestroyFlash(2));
        }
    }

    public void Continue()
    {
        ThirdPersonCharacterController.isRoaming = true;
        DialogueSystem.isTalking = false;
        Destroy(completeGamePanel);
        Destroy(this);
    }

    public void Quit()
    {
        //?SceneManager.LoadScene("Start")
    }

    IEnumerator DestroyFlash(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(flash);
    }
}
