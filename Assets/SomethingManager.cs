using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ObjectName
{
    //Sign,
    Bus,
    Ambulance,
    //Car,
    TrafficLight,
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
        grabObjectsByType[ObjectName.TrafficLight] = new List<GameObject>(allGrabObjects).GetRange(2, 3);
        grabObjectsByType[ObjectName.Bus] = new List<GameObject> { allGrabObjects[0] };
        grabObjectsByType[ObjectName.Ambulance] = new List<GameObject> { allGrabObjects[1] };
        // Similar logic for snap objects
        //snapObjectsByType[ObjectType.Sign] = new List<GameObject>(allSnapObjects).GetRange(0, 2);
        //snapObjectsByType[ObjectType.Bus] = new List<GameObject>(allSnapObjects).GetRange(2, 2);
        //snapObjectsByType[ObjectType.Ambulance] = new List<GameObject>(allSnapObjects).GetRange(4, 2);
        //snapObjectsByType[ObjectType.Car] = new List<GameObject>(allSnapObjects).GetRange(6, 2);
        snapObjectsByType[ObjectName.TrafficLight] = new List<GameObject>(allSnapObjects).GetRange(4, 3);
        snapObjectsByType[ObjectName.Bus] = new List<GameObject>(allSnapObjects).GetRange(0, 2);
        snapObjectsByType[ObjectName.Ambulance] = new List<GameObject>(allSnapObjects).GetRange(2, 2);
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
}
