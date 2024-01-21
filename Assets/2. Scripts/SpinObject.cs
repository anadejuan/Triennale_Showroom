using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    // Specify the axis around which the object should spin
    public Vector3 spinAxis = Vector3.up;

    // Specify the rotation speed in degrees per second
    public float rotationSpeed = 30.0f;

    void Update()
    {
        // Rotate the object around the specified axis at a constant speed
        transform.Rotate(spinAxis, rotationSpeed * Time.deltaTime);
    }
}