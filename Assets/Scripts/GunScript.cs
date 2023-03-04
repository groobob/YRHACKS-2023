using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float projectileLifeTime = 3f;
    public float fireRate = 1;
    public float impactForce = 60f;
    public float projectileForce = 300f;


    public Camera fpsCam;
    public GameObject viewModel;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public GameObject missile;

    private float nextTimeToFire = 0f;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeToFire-0.2)
        {
            animator.SetBool("HasRocket", true);
        }

        
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= nextTimeToFire)
            {
                Shoot();
                animator.SetBool("HasRocket", false);
                nextTimeToFire = Time.time + fireRate;
                
                Debug.Log("Fired");
            }
        }
    }

    void Shoot()
    {
        //muzzleFlash.Play();

        GameObject missileShot = Instantiate(missile, viewModel.transform.position, fpsCam.transform.rotation);
        Rigidbody rb = missileShot.GetComponent<Rigidbody>();
        rb.AddForce(rb.transform.forward * projectileForce, ForceMode.Impulse);

        Debug.Log(missileShot);

        Destroy(missileShot, projectileLifeTime);
        /*

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                //target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            //GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            //Destroy(impactGO, 2f);
        }
        */
    }
}
