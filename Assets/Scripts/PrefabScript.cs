using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabScript : MonoBehaviour
{
    public Transform myPrefab;
    private int count, amount;

    // Start is called before the first frame update
    void Start()
    {
        // Count the number of objects created
        count = 0;

        // The amount how many objects should be created
        amount = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        // Set a random spawn position
        float spawnPosX = Random.Range(-5.0f, 5.0f);
        float spawnPosZ = Random.Range(-5.0f, 5.0f);
        if (count != amount)
        {
            // Set the vector 3 position
            Vector3 spawnPos = new Vector3(spawnPosX, 0.0f, spawnPosZ);

            // Instantiate copies of Prefab each with different rotations
            Instantiate(myPrefab, spawnPos, Quaternion.Euler(0, Random.Range(0, 180), 0));
            count++;
        }
    }
}
