using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class worldBoundaryScript : MonoBehaviour
{
    private Transform player;
    private float dist;
    private float worldBounds = 50000f;

    public GameObject worldBoundCentre;

    public GameObject playerShip;

    //timer
    float currentTime = 0;
    float startingTime = 10f;

    [SerializeField] TextMeshProUGUI countdownTextNumber;

    [SerializeField] private GameObject worldBoundsWarningText;  // UI TEXT
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private GameObject deathTextGroup;  // UI TEXT
    [SerializeField] private TextMeshProUGUI deathText;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        worldBoundsWarningText.SetActive(false);    //Hide gravity warning

        currentTime = startingTime;
    }

    void Update()
    {
        dist = Vector3.Distance(worldBoundCentre.transform.position, transform.position);

        if (currentTime > 0)
        {
            if (dist >= worldBounds)
            {
                triggerWarning();
            }
            else
            {
                currentTime = startingTime; // reset timer when back in battlefield
                worldBoundsWarningText.SetActive(false);
            }
        }
        else
        {
            killPlayer();
        }
    }

    private void triggerWarning()
    {
        //Debug.Log("Player is leaving battleField");
        //worldBoundsWarningText.SetActive(true);    //Show gravity warning
        //transform.position = Vector3.MoveTowards(transform.position, moonSurface.transform.position, gravSpeed * Time.deltaTime);

        currentTime -= 1 * Time.deltaTime;
        countdownTextNumber.text = currentTime.ToString("0");
        //text.text = "You are entering Deep Space";

        worldBoundsWarningText.SetActive(true);
    }

    public void killPlayer()
    {
        worldBoundsWarningText.SetActive(false);
        deathTextGroup.SetActive(true);

        playerShip.SetActive(false);
        GetComponent<shipController>().enabled = false;

        //Debug.Log("You have died");
    }
}
