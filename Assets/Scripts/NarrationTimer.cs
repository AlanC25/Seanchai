using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NarrationTimer : MonoBehaviour
{
    [SerializeField]
    private string sceneNameToLoad;

    public FadeScript fScript;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForNarration());
    }

    IEnumerator WaitForNarration()
    {
        yield return new WaitForSeconds(11);
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
