using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moonGrav : MonoBehaviour
{
    private Transform player;
    private float dist;
    private float gravTriggerZone = 20000f;   //20000f;
    private float deathZone = 5000f;    //Distance from center to surfaces
    private float gravStrength = 0.04f; //0.1
    private float gravSpeed;

    public GameObject moonSurface;

    //ui
    [SerializeField] private GameObject gravWarningText;  // UI TEXT
    [SerializeField] private Text text;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gravWarningText.SetActive(false);    //Hide gravity warning
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(moonSurface.transform.position, transform.position);

        gravSpeed = (gravTriggerZone - dist) * gravStrength;

        if (dist <= gravTriggerZone)
        {
            //Debug.Log("Moon grav is active, dist: " + dist);
            text.text = "Gravity Field Detected!";
            gravWarningText.SetActive(true);    //Show gravity warning

            transform.position = Vector3.MoveTowards(transform.position, moonSurface.transform.position, gravSpeed * Time.deltaTime);
        }

        if (dist > gravTriggerZone)
        {
            gravWarningText.SetActive(false);    //Hide gravity warning
        }

        if (dist <= deathZone)
        {
            killPlayer();
        }
    }

    public void killPlayer()
    {
        Debug.Log("You have died");

    }
}

//https://www.youtube.com/watch?v=oeqnYxS3JJc