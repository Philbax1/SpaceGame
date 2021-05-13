using UnityEngine;

public class enemyTarget : MonoBehaviour
{
    public float health = 100f;

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
        Destroy(gameObject);
    }
}
