using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Camera fpsCam;
    public int Variant;
    void Start()
    {
        fpsCam = FindObjectOfType<Camera>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player Touched");

            // Call function to give buff here
            GameObject player = other.gameObject;
            if (Variant == 1)
            {
                fpsCam.GetComponent<GunScript>().GiveAttackSpeed();
            } else
            {
                fpsCam.GetComponent<GunScript>().GiveExplosionBuff();
            }
            
            
            gameObject.SetActive(false);
            Destroy(gameObject, 5f);
        }
    }
}
