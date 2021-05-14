using UnityEngine;
using System.Collections;
using System;

public class enemyTarget : MonoBehaviour
{
    private float health = 100f;

    public ParticleSystem destroyEffect;
    public AudioSource destroyNoise;


    public void takeDamge(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            destroyNoise.Play();
            destroyEffect.Play(); //plays muzzle animation
            Die();
        }
    }

    void Die()
    {
        //pauseForDestroy();
        Destroy(gameObject);
    }

    /* IEnumerable pauseForDestroy()
    {
        yield return new WaitForSeconds(2);
    }*/


}
