using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject overlay;

    public Animator myAnimator;

    public AudioClip hurt;

    public bool playDeathSound = true;

    public string sceneNameToLoad;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.enabled = true;

        Animator fadeAnimator = overlay.GetComponent<Animator>();
        fadeAnimator.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -5)
        {
            FallDie();
        }
    }

    public void Die()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(hurt);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0.25f;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        myAnimator.SetBool("isRunning", false);
        myAnimator.SetBool("isDead", true);
        overlay.GetComponent<Animator>().SetTrigger("FadeOutNoAnimEvent");
        StartCoroutine("WaitForFade");
    }

    public void FallDie()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (playDeathSound == true)
        {
            audio.PlayOneShot(hurt);
            playDeathSound = false;
        }
        GetComponent<BoxCollider2D>().enabled = false;
        myAnimator.SetBool("isRunning", false);
        myAnimator.SetBool("isDead", true);
        overlay.GetComponent<Animator>().SetTrigger("FadeOutNoAnimEvent");
        StartCoroutine("WaitForFade");
    }

    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
