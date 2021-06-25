using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aesteroidCollision : MonoBehaviour
{

    private Transform player;
    private Transform aesteroid;
    private float dist;
    private float collisionDistance = 100f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        aesteroid = GameObject.FindGameObjectWithTag("aesteroid").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, aesteroid.transform.position);

        if (dist <= collisionDistance)
        {
            Debug.Log("aesteroid collision test");
        }
    }
}
