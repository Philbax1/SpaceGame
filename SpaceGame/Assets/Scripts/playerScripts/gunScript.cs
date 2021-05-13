
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public float damage = 25f;
    public float range = 10000f;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            enemyTarget target = hit.transform.GetComponent<enemyTarget>();

            if (target != null)
            {
                target.takeDamge(damage);
            }
        }
    }
}
