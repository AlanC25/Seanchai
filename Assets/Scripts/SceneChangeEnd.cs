using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeEnd : MonoBehaviour
{
    public string sceneNameToLoad;
    private string level;

    public Animator myAnimator;
    public AudioClip openPage, closePage;

    public void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(openPage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FadeToLevel(sceneNameToLoad);
    }

    public void FadeToLevel(string sceneNameToLoad)
    {
        level = sceneNameToLoad;
        myAnimator.SetTrigger("FadeOut");
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(closePage);
    }

    //called by animation event
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(level);
    }
}
