using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGeneratorScript : MonoBehaviour
{
    public Vector3 centerLaneStart;
    public float laneSpacing;
    public float minDistance;
    public float maxDistance;
    public List<GameObject> carPrefabs;
    public int totalCars;

    private void Start()
    {
        GenerateCars();
    }

    private void GenerateCars()
    {
        float currentZPosition = centerLaneStart.z;
        
        for (int i = 0; i < totalCars; i++)
        {
            // Choose a random car prefab
            GameObject carPrefab = carPrefabs[Random.Range(0, carPrefabs.Count)];

            // Calculate the size of the car
            Renderer carRenderer = carPrefab.GetComponentInChildren<Renderer>();
            float carLength = carRenderer.bounds.size.z;

            // Add random distance plus the length of the car to the current position
            currentZPosition += carLength / 2 + Random.Range(minDistance, maxDistance);

            // Choose a random lane: -1 for left, 0 for center, 1 for right
            int lane = Random.Range(-1, 2);
            Vector3 spawnPosition = new Vector3(centerLaneStart.x + lane * laneSpacing, centerLaneStart.y, currentZPosition);

            // Instantiate the car
            GameObject newCar = Instantiate(carPrefab, spawnPosition, Quaternion.identity);

            // Update currentZPosition for the next car
            currentZPosition += carLength / 2;
        }
    }
}
