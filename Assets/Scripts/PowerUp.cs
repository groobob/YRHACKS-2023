using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something touched");
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player Touched");
        }
    }
}
