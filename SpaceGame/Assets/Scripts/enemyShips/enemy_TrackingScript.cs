using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;


public class enemy_TrackingScript : MonoBehaviour
{
    private Transform player;
    private float dist;
    private float followRange = 40000f, attackRange = 20000f, moveSpeed = 1000f, attackingMoveSpeed = 1400F, primDamage = 25;

    float currentTime = 0, startingTime = 3f;

    [SerializeField] LineRenderer lineRend;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);
        //Debug.Log("Distance is : " + dist);

        if (dist <= followRange && dist > attackRange) followState();

        if (dist <= attackRange)
        {
            currentTime -= 1 * Time.deltaTime;
            Debug.Log("Timer working" + currentTime.ToString());
            attackState();

            if (currentTime <= 1)
            {
                Debug.Log("Timer working" + currentTime.ToString());
                currentTime = startingTime;
                attackPlayer();
            }
        }

        else
        {
            Debug.Log("patrol state");
            patrollingState();
        }
    }

    private void followState()
    {
        Debug.Log("Follow state activated");
        transform.LookAt(player);
        GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed * Time.deltaTime);
    }

    private void attackState()
    {
        Debug.Log("Attack state activated");
        transform.LookAt(player);
        GetComponent<Rigidbody>().AddForce(transform.forward * attackingMoveSpeed * Time.deltaTime);
    }

    private void patrollingState()
    {
        Debug.Log("Patrol state activated");
        //GetComponent<Rigidbody>().AddForce(transform.forward * 0 * Time.deltaTime);
    }


    void attackPlayer()
    {
        //baseAttackNoise.Play();
        //muzzleFlash.SetActive(true);

        RaycastHit hit;

        //Instantiate(pfBullet, fpsCam.transform.position, Quaternion.identity);

        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {
            //Debug.Log(hit.transform.name);

            if (hit.transform.name == "Player")
            {
                enemyTarget target = hit.transform.GetComponent<enemyTarget>();

                if (target != null)
                {
                    Debug.Log(target);
                    //target.takeDamge(primDamage);
                }
            }

            //muzzleFlash.SetActive(false);

            //GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            //impactGO.Play();
            //Destroy(impactGO, 2f); 
        }
    }

    IEnumerator renderLaser2(RaycastHit hit)
    {
        lineRend.enabled = true;
        lineRend.SetPosition(0, transform.position);
        lineRend.SetPosition(1, hit.point);
        yield return new WaitForSeconds(0.5f);
        lineRend.enabled = false;
    }
}

// https://www.youtube.com/watch?v=C1my9i_5RDw
