using UnityEngine;
using System.Collections;
using System;

public class enemyTarget : MonoBehaviour
{
    private float health = 100f;

    public GameObject impactEffect;
    public GameObject deathEffect;

    public void takeDamge(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            Die();
        }
        else
        {
            GameObject impactGO = Instantiate(impactEffect, transform.position, Quaternion.LookRotation(transform.position));
        }
    }

    void Die()
    {
        //Debug.Log(gameObject);
        GameObject impactGO = Instantiate(deathEffect, transform.position, Quaternion.LookRotation(transform.position));
        //impactGO.Play();
        Destroy(impactGO, 2f);

        Destroy(gameObject);
    }

    /*IEnumerable pauseForDestroy()
    {
        yield return new WaitForSeconds(3);
    }*/
}

//https://www.youtube.com/watch?v=THnivyG0Mvo&t=567s
