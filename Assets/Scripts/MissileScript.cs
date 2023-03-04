using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    [SerializeField] public float explosionRadius = 5;
    [SerializeField] public float explosionForce = 500;
    [SerializeField] private GameObject explosionParticle;
    [SerializeField] private GameObject strongExplosionParticle;
    public float damage;
    float defaultRadius;

    private void Awake()
    {
        defaultRadius = explosionRadius;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var surroundingObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        
        foreach(var obj in surroundingObjects) 
        {
            if (obj.gameObject.tag == "Destructable")
            {
                obj.gameObject.GetComponent<Target>().TakeDamage(damage / 2);
                if (obj.gameObject.GetComponent<Target>().health <= 0) obj.GetComponent<Target>().Shatter();
            }
            var rb = obj.GetComponent<Rigidbody>();
            if(rb == null) continue;

            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }

        if(explosionRadius <= defaultRadius) Instantiate(explosionParticle, collision.contacts[0].point, Quaternion.identity);
        else Instantiate(strongExplosionParticle, collision.contacts[0].point, Quaternion.identity);

        Destroy(gameObject);
    }
}