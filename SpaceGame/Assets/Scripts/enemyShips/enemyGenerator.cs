using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGenerator : MonoBehaviour
{
    public GameObject enemiesToSpread;

    private int numEnemiesSpawn = 10;
    private float enemyXSpread = 10000;
    private float enemyYSpread = 10000;
    private float enemyZSpread = 10000;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numEnemiesSpawn; i++)
        {
            createAesteroidField();
        }
    }

    void createAesteroidField()
    {
        Vector3 randPosition = new Vector3(Random.Range(-enemyXSpread, enemyXSpread), Random.Range(-enemyYSpread, enemyYSpread), Random.Range(-enemyZSpread, enemyZSpread)) + transform.position;
        GameObject aesteroidClone = Instantiate(enemiesToSpread, randPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

//https://www.youtube.com/watch?v=tyS7WKf_dtk