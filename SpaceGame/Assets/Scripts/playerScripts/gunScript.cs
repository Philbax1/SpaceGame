using UnityEngine;

public class gunScript : MonoBehaviour
{
    private float damage = 100f;
    private float range = 100000f;
    //public float fireRate = 1f;           //Code for full auto

    public Camera fpsCam;
    public ParticleSystem muzzle;
    public GameObject impactEffect;
    public AudioSource baseAttackNoise;

    //private float nextTimeToFire = 0f;           //Code for full auto

    void Start()
    {
        baseAttackNoise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))// && Time.time >= nextTimeToFire          //Insert in IF statement           //Code for full auto
        {
            //nextTimeToFire = Time.time + 1f / fireRate;           //Code for full auto
            Shoot();
        }
    }

    void Shoot()
    {
        baseAttackNoise.Play();
        muzzle.Play(); //plays muzzle animation

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            enemyTarget target = hit.transform.GetComponent<enemyTarget>();

            if (target != null)
            {
                Debug.Log("target");
                target.takeDamge(damage);
            }

            /* if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            } */

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
