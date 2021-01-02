using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private float timeLeft = 120;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;

    public AudioClip coin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        }
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.name == "EndLevel")
        {
            CountScore();
        }
        if (trigger.gameObject.tag == "coin")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(coin);

            ScoreScript.scoreValue += 100;
            Destroy(trigger.gameObject);
        }
    }

    void CountScore()
    {
        ScoreScript.scoreValue = ScoreScript.scoreValue + (int)(timeLeft * 10);
    }
}
