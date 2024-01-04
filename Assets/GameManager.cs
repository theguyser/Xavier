using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    // Assuming these arrays contain all objects and spots, respectively
    public GameObject[] allGrabObjects;
    public GameObject[] allSnapObjects;

    // Dictionary to store objects based on type
    private Dictionary<ObjectType, List<GameObject>> grabObjectsByType;
    private Dictionary<ObjectType, List<GameObject>> snapObjectsByType;
    private Dictionary<ObjectType, List<Quaternion>> correctRotationsByType;


    void Start()
    {
        InitializeObjects();
    }

    private void InitializeObjects()
    {
        grabObjectsByType = new Dictionary<ObjectType, List<GameObject>>();
        snapObjectsByType = new Dictionary<ObjectType, List<GameObject>>();
        correctRotationsByType = new Dictionary<ObjectType, List<Quaternion>>();

        // Initialize based on your game's logic
        // Initialize these based on your game's logic
        // For example, if the first 4 are traffic lights and the 5th is a speed bump
        grabObjectsByType[ObjectType.TrafficLight] = new List<GameObject>(allGrabObjects).GetRange(0, 4);
        grabObjectsByType[ObjectType.SpeedBump] = new List<GameObject> { allGrabObjects[4] };

        // Similar logic for snap objects
        snapObjectsByType[ObjectType.TrafficLight] = new List<GameObject>(allSnapObjects).GetRange(0, 5);
        snapObjectsByType[ObjectType.SpeedBump] = new List<GameObject>(allSnapObjects).GetRange(5, 4);

        List<Quaternion> trafficLightRotations = new List<Quaternion>();
        for (int i = 0; i < 4; i++)  // Assuming the first 5 are traffic lights
        {
            trafficLightRotations.Add(allSnapObjects[i].transform.rotation);
        }
        correctRotationsByType[ObjectType.TrafficLight] = trafficLightRotations;
        
        List<Quaternion> speedBumpRotations = new List<Quaternion>();
        for (int i = 5; i < 7; i++)  // Assuming the next 4 are speed bumps
        {
            speedBumpRotations.Add(allSnapObjects[i].transform.rotation);
        }
        correctRotationsByType[ObjectType.SpeedBump] = speedBumpRotations;

    }

    public List<GameObject> GetGrabObjects(ObjectType type)
    {
        return grabObjectsByType[type];
    }

    public Vector3 GetSnapObjectPosition(ObjectType type, int index)
    {
        return snapObjectsByType[type][index].transform.position;
    }
    public Quaternion GetSnapObjectRotation(ObjectType type, int index)
    {
        return snapObjectsByType[type][index].transform.rotation;
    }
    public List<Quaternion> GetCorrectRotations(ObjectType type)
    {
        return correctRotationsByType[type];
    }

    public int GetNumberOfObjects(ObjectType type)
    {
        return grabObjectsByType[type].Count;
    }
}