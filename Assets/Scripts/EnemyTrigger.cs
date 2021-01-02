using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject fallingRock;

    public GameObject blast;
    public GameObject enemyOne;

    public GameObject enemyTwo;
    public GameObject rockSmashSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(RockFalling());
        }
    }

    IEnumerator RockFalling()
    {
        fallingRock.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        blast.SetActive(true);
        rockSmashSound.SetActive(true);
        fallingRock.SetActive(false);
        yield return new WaitForSeconds(1f);
        enemyOne.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        rockSmashSound.SetActive(false);
        enemyTwo.SetActive(true);
        Destroy(fallingRock);
    }
}
