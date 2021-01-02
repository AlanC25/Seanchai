using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtTarget : MonoBehaviour
{
    public Transform target;

    public bool hasStoodUp = false;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(Stall());
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStoodUp)
        {
            Vector3 relativePos = target.position - transform.position;
            Quaternion LookAtRotation = Quaternion.LookRotation( relativePos );
  
            Quaternion LookAtRotationOnly_Y = Quaternion.Euler(transform.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, LookAtRotationOnly_Y, Time.deltaTime * 1);

           
        }
    }

    IEnumerator Stall()
    {
        yield return new WaitForSeconds(3);
        hasStoodUp = true;
    }
}
