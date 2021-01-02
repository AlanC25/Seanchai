using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    private GameObject player;
    private float xMin = 0;
    private float xMax = 180;
    private float yMin = 0;
    private float yMax = 0;
    private float offset = 5f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        

        gameObject.transform.position = new Vector3(x + offset, y, gameObject.transform.position.z);
    }
}
