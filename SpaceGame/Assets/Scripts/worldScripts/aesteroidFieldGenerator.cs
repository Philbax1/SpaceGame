using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aesteroidFieldGenerator : MonoBehaviour
{
    public GameObject aesteroidToSpread;

    private int numAesteroidsSpawn = 5000;
    private float aesteroidXSpread = 100000;
    private float aesteroidYSpread = 100000;
    private float aesteroidZSpread = 100000;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numAesteroidsSpawn; i++)
        {
            createAesteroidField();
        }
    }

    void createAesteroidField()
    {
        Vector3 randPosition = new Vector3(Random.Range(-aesteroidXSpread, aesteroidXSpread), Random.Range(-aesteroidYSpread, aesteroidYSpread), Random.Range(-aesteroidZSpread, aesteroidZSpread)) + transform.position;

        GameObject aesteroidClone = Instantiate(aesteroidToSpread, randPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

//https://www.youtube.com/watch?v=tyS7WKf_dtk