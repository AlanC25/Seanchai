using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RepeatScene : MonoBehaviour
{
    [SerializeField]
    private string sceneNameToLoad;

    public FadeScript fScript;

    void OnTriggerEnter(Collider other)
    {
        fScript.playFadeAnim();
        StartCoroutine(WaitForFade());
    }

    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
