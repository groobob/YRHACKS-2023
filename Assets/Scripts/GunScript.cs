using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] public float damage = 10f;
    [SerializeField] public float explosionRadius = 5;
    [SerializeField] public float explosionForce = 500;

    public float projectileLifeTime = 3f;
    public float fireRate = 1;
    public float impactForce = 60f;
    public float projectileForce = 300f;
    private float nextTimeToFire = 0f;

    public Camera fpsCam;
    public GameObject viewModel;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public GameObject missile;
    public Animator animator;

    private float attackBuffAmount = 1/4f;
    private float attackBuffDuration = 5f;

    private float explosionBuffForce = 800;
    private float explosionBuffDamage = 25f;
    private float explosionBuffRadius = 10;
    private float explosionBuffDuration = 8f;
    public AudioSource playSound;
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
                playSound.Play();
                Debug.Log("Fired");
            }
        }
    }

    void Shoot()
    {
        //muzzleFlash.Play();

        GameObject missileShot = Instantiate(missile, fpsCam.transform.position, fpsCam.transform.rotation);
        missileShot.transform.Rotate(0, -90f, 0, Space.Self);
        missileShot.GetComponent<MissileScript>().damage = damage;
        missileShot.GetComponent<MissileScript>().explosionRadius = explosionRadius;
        missileShot.GetComponent<MissileScript>().explosionForce = explosionForce;
        
        Rigidbody rb = missileShot.GetComponent<Rigidbody>();
        rb.AddForce(rb.transform.right * projectileForce, ForceMode.Impulse);

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

    public IEnumerator AttackSpeedBuff()
    {
        Debug.Log("Attack Speed Buff");
        float oldFireRate = fireRate;
        fireRate = attackBuffAmount;
        yield return new WaitForSeconds(attackBuffDuration);
        Debug.Log("Finished");
        fireRate = oldFireRate;
    }

    public void GiveAttackSpeed()
    {
        StartCoroutine(AttackSpeedBuff());
    }

    public IEnumerator ExplosionBuff()
    {
        Debug.Log("Explosion Buff");
        
        float oldForce = explosionForce;
        float oldDamage = damage;
        float oldRadius = explosionRadius;

        explosionForce = explosionBuffForce;
        damage = explosionBuffDamage;
        explosionRadius = explosionBuffRadius;
        yield return new WaitForSeconds(explosionBuffDuration);
        Debug.Log("Finished");
        explosionForce = oldForce;
        explosionRadius = oldRadius;
        damage = oldDamage;
    }

    public void GiveExplosionBuff()
    {
        StartCoroutine(ExplosionBuff());
    }
}
