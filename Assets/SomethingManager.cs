using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ObjectName
{
    //Sign,
    Bus,
    Ambulance,
    //Car,
    Barier,
    //SpeedBump
}
public class SomethingManager : MonoBehaviour
{
    public GameObject[] allGrabObjects;
    public GameObject[] allSnapObjects;
    private Dictionary<ObjectName, List<GameObject>> grabObjectsByType;
    private Dictionary<ObjectName, List<GameObject>> snapObjectsByType;
    private void Start()
    {
        InitializeObjects();
        DebugSnapObjectPositions();
    }
    private void Update()
    {
        // Check if the 'D' key is pressed
        if (Input.GetKeyDown(KeyCode.D))
        {
            DebugSnapObjectPositions(); // Call the method to debug snap object positions
        }
    }
    private void InitializeObjects()
    {
        grabObjectsByType = new Dictionary<ObjectName, List<GameObject>>();
        snapObjectsByType = new Dictionary<ObjectName, List<GameObject>>();

        // Initialize based on your game's logic
        // Initialize these based on your game's logic
        // For example, if the first 4 are traffic lights and the 5th is a speed bump
        //grabObjectsByType[ObjectType.Sign] = new List<GameObject> { allGrabObjects[0] };
        //grabObjectsByType[ObjectType.Bus] = new List<GameObject> { allGrabObjects[1] };
        //grabObjectsByType[ObjectType.Ambulance] = new List<GameObject> { allGrabObjects[2] };
        //grabObjectsByType[ObjectType.Car] = new List<GameObject> { allGrabObjects[3] };
        grabObjectsByType[ObjectName.Barier] = new List<GameObject>{ allGrabObjects[2] };
        grabObjectsByType[ObjectName.Bus] = new List<GameObject> { allGrabObjects[0] };
        grabObjectsByType[ObjectName.Ambulance] = new List<GameObject> { allGrabObjects[1] };
        // Similar logic for snap objects
        //snapObjectsByType[ObjectType.Sign] = new List<GameObject>(allSnapObjects).GetRange(0, 2);
        //snapObjectsByType[ObjectType.Bus] = new List<GameObject>(allSnapObjects).GetRange(2, 2);
        //snapObjectsByType[ObjectType.Ambulance] = new List<GameObject>(allSnapObjects).GetRange(4, 2);
        //snapObjectsByType[ObjectType.Car] = new List<GameObject>(allSnapObjects).GetRange(6, 2);
        snapObjectsByType[ObjectName.Barier] = new List<GameObject>{ allSnapObjects[4] };
        snapObjectsByType[ObjectName.Bus] = new List<GameObject>(allSnapObjects).GetRange(0, 2);
        snapObjectsByType[ObjectName.Ambulance] = new List<GameObject>(allSnapObjects).GetRange(2, 2);
        foreach (var type in grabObjectsByType.Keys)
        {
            Debug.Log("Type: " + type + ", Grab Count: " + grabObjectsByType[type].Count);
        }

        foreach (var type in snapObjectsByType.Keys)
        {
            Debug.Log("Type: " + type + ", Snap Count: " + snapObjectsByType[type].Count);
        }
    }
    
    

    public List<GameObject> GetGrabObjects(ObjectName type)
    {
        return grabObjectsByType[type];
    }

    public Vector3 GetSnapObjectPosition(ObjectName type, int index)
    {
        return snapObjectsByType[type][index].transform.position;
    }

    public int GetNumberOfObjects(ObjectName type)
    {
        return grabObjectsByType[type].Count;
    }
    private void DebugSnapObjectPositions()
    {
        foreach (ObjectName type in snapObjectsByType.Keys)
        {
            List<GameObject> snapObjects = snapObjectsByType[type];
            for (int i = 0; i < snapObjects.Count; i++)
            {
                GameObject snapObject = snapObjects[i];
                Vector3 position = snapObject.transform.position;
                Debug.Log("Type: " + type + ", Snap Object Index: " + i + ", Position: " + position);
            }
        }
    }
}
