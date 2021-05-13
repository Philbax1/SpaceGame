using UnityEngine;

public class gunScript : MonoBehaviour
{
    public float damage = 25f;
    public float range = 100000f;
    public float fireRate = 1f;
    public float impactForce = 30f;

    public Camera fpsCam;
    public ParticleSystem muzzle;
    public GameObject impactEffect;
    public AudioSource baseAttackNoise;

    private float nextTimeToFire = 0f;

    void Start()
    {
        baseAttackNoise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
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
                target.takeDamge(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
