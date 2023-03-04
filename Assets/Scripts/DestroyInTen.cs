using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInTen : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject, 10f);
    }
}
