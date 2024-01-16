using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform positionA; // Assign in Inspector
    //public Transform positionD; // Assign in Inspector
    //public Transform positioW1; // Assign in Inspector
    public float transitionSpeed = 5f;
    public float smoothTime = 0.3f;// Speed of camera movement
    public float diagonalSpeedMultiplier = 1.5f; 
    
    public Vector3 minBounds; // Minimum bounds for camera movement
    public Vector3 maxBounds;
    
    private Vector3 velocity = Vector3.zero;
    private Transform targetPosition;
    private Quaternion initialRotation;
    void Start()
    {
        // Store the initial rotation of the camera
        initialRotation = Quaternion.Euler(142.681f, 0f, 180f);
    }
    void Update()
    {
        Vector3 checkPosition = transform.position;
        bool isMovingHorizontally = false;
        bool isMovingVertically = false;
        // Check for input and update target position
        if (Input.GetKey(KeyCode.A))
        {
              checkPosition += new Vector3(transitionSpeed,0f, 0f);
            //checkPosition.position = targetPosition.position;
            isMovingHorizontally = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
             checkPosition += new Vector3(-transitionSpeed ,0f, 0f);
             isMovingHorizontally = true;
        }

        
        if (Input.GetKey(KeyCode.W))
        {
            checkPosition+= new Vector3(0f,0f,-transitionSpeed);
            isMovingVertically = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
             checkPosition+= new Vector3(0f,0f,transitionSpeed);
             isMovingVertically = true;
        }
        if (isMovingHorizontally && isMovingVertically)
        {
            checkPosition += (checkPosition - transform.position).normalized * diagonalSpeedMultiplier * Time.deltaTime;
        }

        checkPosition.x = Mathf.Clamp(checkPosition.x, minBounds.x, maxBounds.x);
        checkPosition.y = Mathf.Clamp(checkPosition.y, minBounds.y, maxBounds.y);
        checkPosition.z = Mathf.Clamp(checkPosition.z, minBounds.z, maxBounds.z);

        //argetPosition.position = checkPosition;
        // Move camera towards target position
       
        //transform.position = Vector3.Lerp(transform.position, checkPosition, transitionSpeed * Time.deltaTime);
        transform.position = Vector3.SmoothDamp(transform.position, checkPosition, ref velocity, smoothTime);
        transform.rotation = initialRotation;
        
    }
}


