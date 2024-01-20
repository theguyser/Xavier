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


    void Start()
    {
        InitializeObjects();
    }

    private void InitializeObjects()
    {
        grabObjectsByType = new Dictionary<ObjectType, List<GameObject>>();
        snapObjectsByType = new Dictionary<ObjectType, List<GameObject>>();

        // Initialize based on your game's logic
        // Initialize these based on your game's logic
        // For example, if the first 4 are traffic lights and the 5th is a speed bump
        //grabObjectsByType[ObjectType.Sign] = new List<GameObject> { allGrabObjects[0] };
        grabObjectsByType[ObjectType.Bus] = new List<GameObject> { allGrabObjects[0] };
        grabObjectsByType[ObjectType.Ambulance] = new List<GameObject> { allGrabObjects[1] };
        //grabObjectsByType[ObjectType.Car] = new List<GameObject> { allGrabObjects[3] };
        grabObjectsByType[ObjectType.Traffic] = new List<GameObject> (allGrabObjects).GetRange(2,3) ;
        
        // Similar logic for snap objects
        //snapObjectsByType[ObjectType.Sign] = new List<GameObject>(allSnapObjects).GetRange(0, 2);
        snapObjectsByType[ObjectType.Bus] = new List<GameObject>(allSnapObjects).GetRange(0, 2);
        snapObjectsByType[ObjectType.Ambulance] = new List<GameObject>(allSnapObjects).GetRange(2, 2);
        //snapObjectsByType[ObjectType.Car] = new List<GameObject>(allSnapObjects).GetRange(6, 2);
        snapObjectsByType[ObjectType.Traffic] = new List<GameObject>(allSnapObjects).GetRange(4, 3);

    }

    public List<GameObject> GetGrabObjects(ObjectType type)
    {
        return grabObjectsByType[type];
    }

    public Vector3 GetSnapObjectPosition(ObjectType type, int index)
    {
        return snapObjectsByType[type][index].transform.position;
    }

    public int GetNumberOfObjects(ObjectType type)
    {
        return grabObjectsByType[type].Count;
    }
}