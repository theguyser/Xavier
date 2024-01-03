using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum ObjectType
{
    TrafficLight,
    SpeedBump
}
public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    private float correctObjects = 0;
    [SerializeField] TextMeshProUGUI GoodJob;
    [SerializeField] TextMeshProUGUI TryAgain;
    
    public ResetButton resetButton;
    private Dictionary<ObjectType, HashSet<Vector3>> correctSpotPositions;
    private Dictionary<ObjectType, HashSet<Quaternion>> correctSpotRotations;
    
    void Start()
    {
        correctSpotPositions = new Dictionary<ObjectType, HashSet<Vector3>>();
        correctSpotRotations = new Dictionary<ObjectType, HashSet<Quaternion>>();

        // Initialize correct spots for each type
        InitializeCorrectSpots(ObjectType.TrafficLight, 4); // 4 correct spots for traffic lights
        InitializeCorrectSpots(ObjectType.SpeedBump, 2);    // 3 correct spots for speed bumps
    }

    private void InitializeCorrectSpots(ObjectType type, int numberOfSpots)
    {
        HashSet<Vector3> spots = new HashSet<Vector3>();
        HashSet<Quaternion> rotation = new HashSet<Quaternion>();
        for (int i = 0; i < numberOfSpots; i++)
        {
            spots.Add(gameManager.GetSnapObjectPosition(type, i));
            rotation.Add(gameManager.GetSnapObjectRotation(type, i));
        }
        correctSpotPositions[type] = spots;
        correctSpotRotations[type] = rotation;
        Debug.Log("Rotation: " + correctSpotRotations[type]);
    }
   
    public void OnButtonClick()
    {
        int totalCorrectObjects = 0;
        int totalRequiredObjects = 0;

        // Accumulate correct objects for TrafficLight
        totalCorrectObjects += CountCorrectObjects(ObjectType.TrafficLight);
        totalRequiredObjects += gameManager.GetNumberOfObjects(ObjectType.TrafficLight);

        // Accumulate correct objects for SpeedBump
        totalCorrectObjects += CountCorrectObjects(ObjectType.SpeedBump);
        totalRequiredObjects += gameManager.GetNumberOfObjects(ObjectType.SpeedBump);

        // Now check if total correct objects match the total required objects
        if (totalCorrectObjects == totalRequiredObjects)
        {
            GoodJob.gameObject.SetActive(true);
            TryAgain.gameObject.SetActive(false);
        }
        else
        {
            TryAgain.gameObject.SetActive(true);
            GoodJob.gameObject.SetActive(false);
        }
    }
    private int CountCorrectObjects(ObjectType type)
    {
        int correctCount = 0;
        foreach (var obj in gameManager.GetGrabObjects(type))
        {
            if (correctSpotPositions[type].Contains(obj.transform.position) && correctSpotRotations[type].Contains(obj.transform.rotation))
            {
                Debug.Log("Correct: " + obj.name);
                correctCount++;
            }
            else
            {
                Debug.Log("Incorrect: " + obj.name);
            }
        }
        return correctCount;
    }
    
}



