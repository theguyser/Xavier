using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform positionA; // Assign in Inspector
    public Transform positionD; // Assign in Inspector

    public float transitionSpeed = 1f; // Speed of camera movement

    private Transform targetPosition;
    private Quaternion initialRotation;
    void Start()
    {
        // Store the initial rotation of the camera
        initialRotation = transform.rotation;
    }
    void Update()
    {
        // Check for input and update target position
        if (Input.GetKeyDown(KeyCode.A))
        {
            targetPosition = positionA;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            targetPosition = positionD;
        }

        // Move camera towards target position
        if (targetPosition != null)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition.position, transitionSpeed * Time.deltaTime);
            transform.rotation = initialRotation;
        }
    }
}


