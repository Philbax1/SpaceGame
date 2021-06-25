using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gunScript : MonoBehaviour
{
    private float primDamage = 25;
    private float secDamage = 75;
    private float range = 1000000f;
    //public float fireRate = 1f;           //Code for full auto

    public Camera fpsCam;

    //primaryAttack
    public GameObject muzzleFlash;
    public AudioSource baseAttackNoise;

    [SerializeField] LineRenderer lineRend;

    //public Transform pfBullet;


    //secondaryAttack
    public ParticleSystem muzzleFlash2;
    public AudioSource baseAttackNoise2;

    public Transform pfBullet2;

    //public GameObject impactEffect;
    //private float nextTimeToFire = 0f;           //Code for full auto

    void Start()
    {
        baseAttackNoise = GetComponent<AudioSource>();
        baseAttackNoise2 = GetComponent<AudioSource>();

        muzzleFlash.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // && Time.time >= nextTimeToFire          //Insert in IF statement           //Code for full auto
        {
            //nextTimeToFire = Time.time + 1f / fireRate;           //Code for full auto
            primaryShoot();
        }

        if (Input.GetButtonDown("Fire2")) // && Time.time >= nextTimeToFire          //Insert in IF statement           //Code for full auto
        {
            //nextTimeToFire = Time.time + 1f / fireRate;           //Code for full auto
            secondaryShoot();
        }
    }

    void primaryShoot()
    {
        baseAttackNoise.Play();

        //muzzleFlash.SetActive(true);

        RaycastHit hit;
        //Instantiate(pfBullet, fpsCam.transform.position, Quaternion.identity);

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            StartCoroutine(renderLaser(hit));

            if (hit.transform.name == "enemy_spacefighter(Clone)" || hit.transform.name == "enemy_spacefighter")
            {
                enemyTarget target = hit.transform.GetComponent<enemyTarget>();

                if (target != null)
                {
                    //Debug.Log(target);
                    target.takeDamge(primDamage);
                }
            }

            //muzzleFlash.SetActive(false);

            //GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            //impactGO.Play();
            //Destroy(impactGO, 2f);
        }
    }

    void secondaryShoot()
    {
        //Debug.Log("secondary attack working");

        baseAttackNoise2.Play();
        //muzzleFlash.Play(); //plays muzzle animation

        RaycastHit hit2;

        //Instantiate(pfBullet, fpsCam.transform.position, Quaternion.identity);

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit2, range))
        {
            //Debug.Log(hit2.transform.name);

            StartCoroutine(renderLaser(hit2));

            if (hit2.transform.name == "enemy_spacefighter(Clone)" || hit2.transform.name == "enemy_spacefighter")
            {
                enemyTarget target = hit2.transform.GetComponent<enemyTarget>();

                if (target != null)
                {
                    //Debug.Log(target);
                    target.takeDamge(secDamage);
                }
            }
        }
    }


    IEnumerator renderLaser(RaycastHit hit)
    {
        lineRend.enabled = true;
        lineRend.SetPosition(0, fpsCam.transform.position);
        lineRend.SetPosition(1, hit.point);
        yield return new WaitForSeconds(0.5f);
        lineRend.enabled = false;
    }
}

//https://www.youtube.com/watch?v=THnivyG0Mvo&t=567s