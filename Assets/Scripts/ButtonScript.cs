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
    
    void Start()
    {
        correctSpotPositions = new Dictionary<ObjectType, HashSet<Vector3>>();

        // Initialize correct spots for each type
        InitializeCorrectSpots(ObjectType.TrafficLight, 4); // 4 correct spots for traffic lights
        InitializeCorrectSpots(ObjectType.SpeedBump, 1);    // 3 correct spots for speed bumps
    }

    private void InitializeCorrectSpots(ObjectType type, int numberOfSpots)
    {
        HashSet<Vector3> spots = new HashSet<Vector3>();
        for (int i = 0; i < numberOfSpots; i++)
        {
            spots.Add(gameManager.GetSnapObjectPosition(type, i));
        }
        correctSpotPositions[type] = spots;
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
            resetButton.isTimerGoing = false;
        }
        else
        {
            TryAgain.gameObject.SetActive(true);
        }
    }

    private int CountCorrectObjects(ObjectType type)
    {
        int correctCount = 0;
        foreach (var obj in gameManager.GetGrabObjects(type))
        {
            if (correctSpotPositions[type].Contains(obj.transform.position))
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



