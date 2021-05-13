using UnityEngine;
using System.Collections;
using System;

public class enemyTarget : MonoBehaviour
{
    private float health = 0f;

    public ParticleSystem destroyEffect;
    public AudioSource destroyNoise;


    public void takeDamge(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        destroyNoise.Play();
        destroyEffect.Play(); //plays muzzle animation

        //pauseForDestroy();
        Destroy(gameObject);
    }

    /* IEnumerable pauseForDestroy()
    {
        yield return new WaitForSeconds(2);
    }*/


}
