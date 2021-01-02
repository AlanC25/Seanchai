using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
//using UnityEngine.ProBuilder;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    #region Fields

    public float lookRadius;
    private NavMeshAgent agent;
    public Animator enemyAmim;
    private float animationBlend;
    private bool isAttacking = false;
    public static bool hasHit = false;
    public GameObject particleExplode;
    public GameObject rockGuy;
    public Collider collider;
    #endregion

    public Transform target;
    public GameObject hurting;
    private bool isDead = false;
    public GameObject explodeSound;
    #region Methods

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        isDead = false;
    }

    void Update()
    {
        FaceTarget();
        float distance = Vector3.Distance(target.position, transform.position);

        if (!isAttacking)
        {
            agent.enabled = true;
            agent.destination = target.position;
            animationBlend = Mathf.Lerp(animationBlend, 0, 50 * Time.deltaTime);
            enemyAmim.SetFloat("Attention", animationBlend);
        }

        if (isAttacking)
        {
            animationBlend = Mathf.Lerp(animationBlend, 2, 30 * Time.deltaTime);
            enemyAmim.SetFloat("Attention", animationBlend);
            agent.enabled = false; 
            
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 1f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("weapon"))
        {
            //isDead = true;
            StopCoroutine(Attack());
            if (!isDead)
            {
                StartCoroutine(Die());
            }
            
            isAttacking = false;
        }

        if (other.transform.CompareTag("Player"))
        {
            if (isAttacking == false && !isDead) 
            {
                StartCoroutine(Attack());
            }

        }
    }

    IEnumerator Attack()
    {
        hurting.SetActive(false);
        isAttacking = true;
        yield return new WaitForSeconds(0.2f);
        if (!isDead && !GiantAnimations.deathStarted)
        {
            hurting.SetActive(true);
            GiantMovement.health -= 10;
            
        }
        yield return new WaitForSeconds(0.5f);
        
       isAttacking = false; //to delay next attack
       // FaceTarget();
       
    }

    IEnumerator Die()
    {
        explodeSound.SetActive(false);
        explodeSound.SetActive(true);
        //noise plz
        isDead = true;
        CausewayReferee.addKill();
        hasHit = false;
        particleExplode.SetActive(true);
        rockGuy.SetActive(false);
        collider.enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        
        
        
    }

    #endregion
}
