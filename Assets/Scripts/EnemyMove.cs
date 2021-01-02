using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int EnemySpeed;
    public int XMoveDirection;

    public AudioClip howl;

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Flip();
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(howl);
        }
    }

    void Flip()
    {
        if(XMoveDirection > 0)
        {
            XMoveDirection = -1;
            transform.Rotate(new Vector3(0, 180, 0));
        }
        else
        {
            XMoveDirection = 1;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
