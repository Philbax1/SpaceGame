using UnityEngine;
using System.Collections;

public class CannonBehavior : MonoBehaviour
{
    private float damage = 100f;

    public Transform m_cannonRot;
    public Transform m_muzzle;
    public GameObject m_shotPrefab;

    private float dist;
    private float attackRange = 10000f;

    public AudioSource baseAttackNoise;

    //public GameObject impactEffect;

    private Transform player;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);

        if (dist <= attackRange)
        {
            enemyAttack();
        }
        else
        {
            transform.LookAt(player);
        }
    }

    void enemyAttack()
    {
        transform.LookAt(player);
        GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject;
        GameObject.Destroy(go, 3f);
    }

}
