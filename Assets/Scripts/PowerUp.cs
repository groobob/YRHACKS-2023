using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Camera fpsCam;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player Touched");

            // Call function to give buff here
            GameObject player = other.gameObject;
            fpsCam.GetComponent<GunScript>().GiveAttackSpeed();
            gameObject.SetActive(false);
            Destroy(gameObject, 5f);
        }
    }
}
