using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGenerator : MonoBehaviour
{
    public GameObject enemiesToSpread;

    public int numEnemiesSpawn = 10;
    private float enemyXSpread = 30000;
    private float enemyYSpread = 30000;
    private float enemyZSpread = 30000;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numEnemiesSpawn; i++)
        {
            createEnemyField();
        }
    }

    void createEnemyField()
    {
        Vector3 randPosition = new Vector3(Random.Range(-enemyXSpread, enemyXSpread), Random.Range(-enemyYSpread, enemyYSpread), Random.Range(-enemyZSpread, enemyZSpread)) + transform.position;
        GameObject aesteroidClone = Instantiate(enemiesToSpread, randPosition, Quaternion.identity);
    }

}

//https://www.youtube.com/watch?v=tyS7WKf_dtk