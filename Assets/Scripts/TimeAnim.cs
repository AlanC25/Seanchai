using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAnim : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(DelayedAnimation());
    }

    IEnumerator DelayedAnimation()
    {
        int startDelay = Random.Range(1, 5);
        yield return new WaitForSeconds(startDelay);
        animator.Play("Pull Plant");
    }
}
