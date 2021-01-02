using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private int levelToLoad;

    public Animator myAnimator;

    public AudioClip openPage, closePage;

    public void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(openPage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FadeToNextLevel();
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        myAnimator.SetTrigger("FadeOut");
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(closePage);
    }

    //called by animation event
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
