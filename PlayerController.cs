using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    [Range(0, 20)] private int speed;
    [SerializeField]
    [Range(0, 300)] private int turnSpeed;
    private float horizontalAxis;
    private float verticalAxis;

    // Update is called once per frame
    void Update()
    {

        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        // Move the car forwards
        if(verticalAxis == 1)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        };

        // Move the car backwards
        if (verticalAxis == -1)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        };

        // Rotate the car left
        if (horizontalAxis == -1)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * turnSpeed);
        }

        // Rotate the car right
        if (horizontalAxis == 1)
        {
            transform.Rotate(Vector3.back * Time.deltaTime * turnSpeed);
        }
    }
}
