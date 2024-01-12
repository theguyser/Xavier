using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarYMotion : MonoBehaviour
{
    private Vector3 startingPosition;
    public Rigidbody carRigidbody;
    public float rumbleIntensity = 20;
    public float rumbleFrequency = 0.01f; // Time between rumbles

    private float nextRumbleTime = 0f;
    private void Start()
    {
        startingPosition = transform.position;
        //find the car rigidbody
        carRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        ResetPosition();
        ResetPosition();
        if (Time.time >= nextRumbleTime)
        {
            Rumble();
            nextRumbleTime = Time.time + rumbleFrequency;
        }
    }

    void Rumble()
    {
        float newX = Random.Range(-rumbleIntensity, rumbleIntensity);
        float newY = Random.Range(-rumbleIntensity, rumbleIntensity);
        float newZ = Random.Range(-rumbleIntensity, rumbleIntensity);

        // Apply force at random positions
        Vector3 force = new Vector3(newX,newY,newZ);

        Vector3 position = transform.position + Random.insideUnitSphere;

        carRigidbody.AddForceAtPosition(force, position);
    }
    private void ResetRotation()
    {
        if (transform.rotation.x > 0.01f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.rotation.x < -0.01f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void ResetPosition()
    {
        if (transform.position.z > 0.01f)
        {
            transform.position = startingPosition;
        }
        else if (transform.position.z < -0.01f)
        {
            transform.position = startingPosition;
        }
    }
}
