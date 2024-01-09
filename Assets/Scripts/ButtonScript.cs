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
    [SerializeField] private RotationCheckScript rotationCheckScript; // Reference to the RotationCheckScript
    
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
        
        Click(ObjectType.SpeedBump);
        Click(ObjectType.TrafficLight);
    }
    
    public void Click(ObjectType type)
    {
        GoodJob.gameObject.SetActive(false);
        TryAgain.gameObject.SetActive(false);
        correctObjects = 0;
        bool allObjectsCorrectRotation = false;
        foreach (var obj in gameManager.GetGrabObjects(type))
        {
            if (IsObjectCorrect(obj, type))
            {
                Debug.Log("Correct: " + obj.name);
                correctObjects++;
                if (rotationCheckScript != null)
                {
                    bool areRotationsCorrect = rotationCheckScript.CheckRotations(gameManager.GetGrabObjects(type));
                    if (areRotationsCorrect)
                    {
                        Debug.Log("All rotations are correct for type: " + type);
                        allObjectsCorrectRotation = true;
                    }
                    else
                    {
                        Debug.Log("Some rotations are incorrect for type: " + type);
                        allObjectsCorrectRotation = false;
                    }
                }
                else
                {
                    Debug.LogError("RotationCheckScript is not assigned in the inspector.");
                }
            }
            else
            {
                Debug.Log("Incorrect: " + obj.name);
            }
            
        }

        if (correctObjects == gameManager.GetNumberOfObjects(type) && allObjectsCorrectRotation)
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
         if (correctPositions.Contains(obj.transform.position))
         {
             Debug.Log("Position true");
         }
         else
         {
             Debug.Log("Position false");
             
         }
         
         return correctPositions.Contains(obj.transform.position);
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



