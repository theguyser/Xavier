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
        InitializeCorrectSpots(ObjectType.SpeedBump, 2);    // 3 correct spots for speed bumps
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
        
        Click(ObjectType.SpeedBump);
        Click(ObjectType.TrafficLight);
        
        /*(int totalCorrectObjects = 0;
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
        }*/
    }
    
    public void Click(ObjectType type)
    {
        GoodJob.gameObject.SetActive(false);
        TryAgain.gameObject.SetActive(false);
        correctObjects = 0;

        foreach (var obj in gameManager.GetGrabObjects(type))
        {
            if (IsObjectCorrect(obj, type))
            {
                Debug.Log("Correct: " + obj.name);
                correctObjects++;
            }
            else
            {
                Debug.Log("Incorrect: " + obj.name);
            }
        }

        if (correctObjects == gameManager.GetNumberOfObjects(type))
        {
            GoodJob.gameObject.SetActive(true);
            //resetButton.isTimerGoing = false;
        }
        else
        {
            TryAgain.gameObject.SetActive(true);
        }
    }

    private bool IsObjectCorrect(GameObject obj, ObjectType type)
    {
        var correctPositions = correctSpotPositions[type];
        var correctRotations = gameManager.GetCorrectRotations(type);
         if (correctPositions.Contains(obj.transform.position))
         {
             Debug.Log("Position true");
         }
         else
         {
             Debug.Log("Position false");
             
         }
         if (correctRotations.Contains(obj.transform.rotation))
         {
             Debug.Log("Rotation true");
         }
         else
         {
             Debug.Log("Rotation false");
             
         }
         
         return correctPositions.Contains(obj.transform.position) && correctRotations.Contains(obj.transform.rotation);
    }
    
    private bool IsRotationCorrect(Quaternion rotation, List<Quaternion> correctRotations)
    {
        foreach (var correctRotation in correctRotations)
        {
            if (Quaternion.Angle(rotation, correctRotation) <= 5)
                return true;
        }
        return false;
    }
    
   /* private int CountCorrectObjects(ObjectType type)
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
    }*/
    
}



