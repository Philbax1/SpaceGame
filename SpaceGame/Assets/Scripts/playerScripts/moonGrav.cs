using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class moonGrav : MonoBehaviour
{
    private Transform player;
    private float dist;
    private float gravTriggerZone = 80000f;   //20000f;
    private float deathZone = 20000f;    //Distance from center to surfaces
    private float gravStrength = 0.05f; //0.1
    private float gravSpeed;

    public GameObject moonSurface;

    //ui
    [SerializeField] private GameObject gravTextGroup;  // UI TEXT
    [SerializeField] private TextMeshProUGUI gravAlertText;
    [SerializeField] private TextMeshProUGUI graveDistanceText;
    [SerializeField] private TextMeshProUGUI gravStrengthText;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gravTextGroup.SetActive(false);    //Hide gravity warning
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(moonSurface.transform.position, transform.position);

        gravSpeed = (gravTriggerZone - dist) * gravStrength;

        if (dist <= gravTriggerZone)
        {
            //Debug.Log("Moon grav is active, dist: " + dist);
            gravAlertText.text = "Gravity Field Detected!";
            graveDistanceText.text = "Distance to Moon " + dist.ToString();
            gravStrengthText.text = "Gravity Pull Stength " + gravSpeed.ToString();

            gravTextGroup.SetActive(true);    //Show gravity warning

            transform.position = Vector3.MoveTowards(transform.position, moonSurface.transform.position, gravSpeed * Time.deltaTime);
        }

        if (dist > gravTriggerZone)
        {
            gravTextGroup.SetActive(false);    //Hide gravity warning
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