using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float turnspeed = 100.0f;
    private float movespeed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical axis
        float moveVertical = Input.GetAxis("Vertical") * movespeed;
        float moveHorizontal = Input.GetAxis("Horizontal") * movespeed;

        // Move translation along the object's z-axis
        transform.Translate(0.0f, 0.0f, moveVertical * Time.deltaTime);

        // Move translation along the object's x-axis
        transform.Translate(moveHorizontal * Time.deltaTime, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.E))
        {
            // Rotate around the y-axis clockwise
            transform.Rotate(Vector3.up * turnspeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            // Rotate around the y-axis counter clockwise
            transform.Rotate(Vector3.down * turnspeed * Time.deltaTime);
        }
    }
}
