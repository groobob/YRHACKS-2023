using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    public GameObject powerUp1;
    public GameObject powerUp2;
    public GameObject ground;

    public float spawnCD = 8f;

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnCD;
            Vector3 newPos = new Vector3(Random.Range(ground.transform.localScale.x/2, -ground.transform.localScale.x/2), 0.5f, Random.Range(ground.transform.localScale.z/2, -ground.transform.localScale.z/2));
            GameObject newPowerUp = Instantiate(powerUp1, newPos, Quaternion.identity);

            Vector3 newPos2 = new Vector3(Random.Range(ground.transform.localScale.x/2, -ground.transform.localScale.x/2), 0.5f, Random.Range(ground.transform.localScale.z/2, -ground.transform.localScale.z/2));
            GameObject newPowerUp2 = Instantiate(powerUp2, newPos2, Quaternion.identity);

            Debug.Log(newPowerUp);
        }
        
    }
}
