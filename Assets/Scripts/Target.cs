using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject _replacement;
    [SerializeField] private float breakForce = 2;
    [SerializeField] private float collisionMultiplier = 100;
    [SerializeField] private float shatterForce = 1000;
    [SerializeField] private bool broken;
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Shatter();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(broken) return;

        if(collision.relativeVelocity.magnitude >= breakForce && health <= 0 && collision.gameObject.GetComponent<MissileScript>() != null)
        {
            broken = true;

            Vector3 scale = transform.localScale;
            var replacement = Instantiate(_replacement, transform.position, transform.rotation);
            replacement.transform.localScale = scale;

            var rbs = replacement.GetComponentsInChildren<Rigidbody>();
            foreach(var rb in rbs)
            {
                rb.AddExplosionForce(collision.relativeVelocity.magnitude * collisionMultiplier, collision.contacts[0].point, 2);
            }
            Destroy(gameObject);
        }
    }

    void Shatter()
    {
        if (broken) return;
        broken = true;

        Vector3 scale = transform.localScale;
        var replacement = Instantiate(_replacement, transform.position, transform.rotation);
        replacement.transform.localScale = scale;

        var rbs = replacement.GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rbs)
        {
            rb.AddExplosionForce(shatterForce, transform.position, 2);
        }
        Destroy(gameObject);
    }
}
