using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.CompareTag("Destructable"))
        //{
            //Instantiate(_explosion, collision.transform.position, Quaternion.identity);
            //Destroy(collision.collider.gameObject);
        //}

        Destroy(gameObject);
    }
}