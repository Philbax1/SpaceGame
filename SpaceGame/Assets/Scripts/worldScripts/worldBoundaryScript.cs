using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class worldBoundaryScript : MonoBehaviour
{
    private Transform player;
    private float dist;
    private float worldBounds = 200000f;

    public GameObject worldBoundCentre;

    //ui
    [SerializeField] private GameObject worldBoundsWarningText;  // UI TEXT
    [SerializeField] private Text text;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        worldBoundsWarningText.SetActive(false);    //Hide gravity warning
    }



    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(worldBoundCentre.transform.position, transform.position);


        if (dist >= worldBounds)
        {
            triggerWarning();
        }
        if (dist < worldBounds)
        {
            worldBoundsWarningText.SetActive(false);
        }

        /* if (dist <= maxDistance) triggerWarning();
        else Debug.Log(dist);
        */
    }

    private void triggerWarning()
    {
        Debug.Log("Player is leaving battleField");
        //worldBoundsWarningText.SetActive(true);    //Show gravity warning
        //transform.position = Vector3.MoveTowards(transform.position, moonSurface.transform.position, gravSpeed * Time.deltaTime);

        text.text = "You are entering Deep Space";
        worldBoundsWarningText.SetActive(true);
    }
}
