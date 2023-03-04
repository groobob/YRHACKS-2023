using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 5;
    [SerializeField] private float explosionForce = 500;
    [SerializeField] private GameObject particles;
    public float damage;
    private void OnCollisionEnter(Collision collision)
    {
        var surroundingObjects = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(var obj in surroundingObjects) 
        {
            if (obj.gameObject.tag == "Destructable")
            {
                obj.gameObject.GetComponent<Target>().TakeDamage(damage / 2);
            }
            var rb = obj.GetComponent<Rigidbody>();
            if(rb == null) continue;

            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }

        Instantiate(particles, collision.contacts[0].point, Quaternion.identity);

        Destroy(gameObject);
    }
}