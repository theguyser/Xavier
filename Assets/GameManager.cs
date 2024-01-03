using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Assuming these arrays contain all objects and spots, respectively
    public GameObject[] allGrabObjects;
    public GameObject[] allSnapObjects;

    // Dictionary to store objects based on type
    private Dictionary<ObjectType, List<GameObject>> grabObjectsByType;
    private Dictionary<ObjectType, List<GameObject>> snapObjectsByType;
    

    void Start()
    {
        InitializeObjects();
    }

    private void InitializeObjects()
    {
        grabObjectsByType = new Dictionary<ObjectType, List<GameObject>>();
        snapObjectsByType = new Dictionary<ObjectType, List<GameObject>>();
        
        // Initialize these based on your game's logic
        // For example, if the first 4 are traffic lights and the 5th is a speed bump
        grabObjectsByType[ObjectType.TrafficLight] = new List<GameObject>(allGrabObjects).GetRange(0, 4);
        grabObjectsByType[ObjectType.SpeedBump] = new List<GameObject> { allGrabObjects[4] };

        // Similar logic for snap objects
        snapObjectsByType[ObjectType.TrafficLight] = new List<GameObject>(allSnapObjects).GetRange(0, 5);
        snapObjectsByType[ObjectType.SpeedBump] = new List<GameObject>(allSnapObjects).GetRange(5, 4);
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

    public int GetNumberOfObjects(ObjectType type)
    {
        return grabObjectsByType[type].Count;
    }
}