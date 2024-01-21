using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomethingRotation : MonoBehaviour
{
    private Dictionary<ObjectType, List<GameObject>> snapObjectsByType;
    private Dictionary<Vector3, Quaternion> correctRotationsForPositions;
    public SomethingManager something;
    void Start()
    {
        InitializedObjectSpots();
    }

    private void InitializedObjectSpots()
    {
        correctRotationsForPositions = new Dictionary<Vector3, Quaternion>();
        //correctRotationsForPositions.Add(GameObject.Find("car_1 (1)").transform.position, GameObject.Find("car_1 (1)").transform.rotation);
        //Debug.Log(GameObject.Find("TrafficLight").transform.rotation);
        //correctRotationsForPositions.Add(GameObject.Find("ambulance (1)").transform.position, GameObject.Find("ambulance (1)").transform.rotation);
        //Debug.Log(GameObject.Find("TrafficLight.001").transform.rotation);
       // correctRotationsForPositions.Add(GameObject.Find("bus (1)").transform.position, GameObject.Find("bus (1)").transform.rotation);
        //Debug.Log(GameObject.Find("TrafficLight.002").transform.rotation);
        //correctRotationsForPositions.Add(GameObject.Find("Sign 3 (1)").transform.position, GameObject.Find("Sign 3 (1)").transform.rotation);
        //Debug.Log(GameObject.Find("TrafficLight.003").transform.rotation);
        //correctRotationsForPositions.Add(GameObject.Find("Sign 3 (2)").transform.position, GameObject.Find("Sign 3 (2)").transform.rotation);
        //correctRotationsForPositions.Add(GameObject.Find("Traffic Light (1)").transform.position, GameObject.Find("Traffic Light (1)").transform.rotation);
        //correctRotationsForPositions.Add(GameObject.Find("Traffic Light (2)").transform.position, GameObject.Find("Traffic Light (2)").transform.rotation);
        //correctRotationsForPositions.Add(GameObject.Find("Traffic Light (3)").transform.position, GameObject.Find("Traffic Light (3)").transform.rotation);
        // Example: Add correct position-rotation pairs
        // correctRotationsForPositions.Add(new Vector3(x, y, z), Quaternion.Euler(rx, ry, rz));
        // Repeat for each position-rotation pair
        
        
        /*correctRotationsForPositions.Add(GameObject.Find("TrafficLight").transform.position, GameObject.Find("TrafficLight").transform.rotation);
        correctRotationsForPositions.Add(GameObject.Find("TrafficLight.001").transform.position, GameObject.Find("TrafficLight.001").transform.rotation);
        correctRotationsForPositions.Add(GameObject.Find("TrafficLight.002").transform.position, GameObject.Find("TrafficLight.002").transform.rotation);
        correctRotationsForPositions.Add(GameObject.Find("TrafficLight.003").transform.position, GameObject.Find("TrafficLight.003").transform.rotation);
        correctRotationsForPositions.Add(GameObject.Find("speed bump (1)").transform.position, GameObject.Find("speed bump (1)").transform.rotation);*/
        
        correctRotationsForPositions.Add(GameObject.Find("ambulance (1)").transform.position, GameObject.Find("ambulance (1)").transform.rotation);
        correctRotationsForPositions.Add(GameObject.Find("Bus (1)").transform.position, GameObject.Find("Bus (1)").transform.rotation);
        correctRotationsForPositions.Add(GameObject.Find("barier 2").transform.position, GameObject.Find("barier 2").transform.rotation);

        
        
    }
    public bool CheckRotations(List<GameObject> objects)
    {
        foreach (var obj in objects)
        {
            Vector3 position = obj.transform.position;
            Quaternion rotation = obj.transform.rotation;

            if (correctRotationsForPositions.TryGetValue(position, out Quaternion correctRotation))
            {
                Debug.Log("Object name: " + obj.name + " Rotation: " + rotation);
                if (!IsRotationCorrect(rotation, correctRotation))
                {
                    Debug.Log("objects is: " + rotation + " " + correctRotation );
                    return false; // Rotation does not match, return false
                }
            }
        }
        return true; // All rotations are correct
    }

    private bool IsRotationCorrect(Quaternion rotation, Quaternion correctRotation)
    {
        const float tolerance = 5f; // You can adjust the tolerance level
        return Quaternion.Angle(rotation, correctRotation) <= tolerance;
    }
}
