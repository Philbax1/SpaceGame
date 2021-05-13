using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemy_TrackingScript : MonoBehaviour
{
    private Transform player;
    private float dist;
    private float moveSpeed = 8000f, followRange = 100000f, attackRange = 100f, attackingMoveSpeed = 80f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);
        //Debug.Log("Distance is : " + dist);

        if (dist <= followRange) followState();
        //if (dist <= attackRange) attackState();
        else patrollingState();
    }

    private void followState()
    {
        transform.LookAt(player);
        GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed * Time.deltaTime);
    }

    private void attackState()
    {
        transform.LookAt(player);
        GetComponent<Rigidbody>().AddForce(transform.forward * attackingMoveSpeed * Time.deltaTime);
    }

    private void patrollingState()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 0 * Time.deltaTime);
    }
}

// https://www.youtube.com/watch?v=C1my9i_5RDw