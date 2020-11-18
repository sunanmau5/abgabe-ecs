using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour
{
    [SerializeField]
    private Transform player = null;

    // Update is called once per frame
    void Update()
    {
        // Direction = destination - source
        Vector3 directionToFace = player.position - transform.position;

        // Access our current rotation = Quaternion Look Rotation
        transform.rotation = Quaternion.LookRotation(directionToFace);
    }
}
