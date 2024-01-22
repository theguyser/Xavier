using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SomethingCheck : MonoBehaviour
{
    public SomethingManager something;
    [SerializeField] TextMeshProUGUI GoodJob;
    [SerializeField] TextMeshProUGUI TryAgain;
    
    private Dictionary<ObjectName, HashSet<Vector3>> correctSpotPositions;
    void Start()
    {
        correctSpotPositions = new Dictionary<ObjectName, HashSet<Vector3>>();

        // Initialize correct spots for each type
        InitializeCorrectSpots(ObjectName.Barier, 1);
        InitializeCorrectSpots(ObjectName.Bus, 1);    
        InitializeCorrectSpots(ObjectName.Ambulance, 1);
    }

    private void InitializeCorrectSpots(ObjectName type, int numberOfSpots)
    {
        HashSet<Vector3> spots = new HashSet<Vector3>();
        for (int i = 0; i < numberOfSpots; i++)
        {
            spots.Add(something.GetSnapObjectPosition(type, i));
        }
        correctSpotPositions[type] = spots;
    }

    public void OnButtonClick()
    {
        int totalCorrectObjects = 0;
        int totalRequiredObjects = 0;
        TryAgain.gameObject.SetActive(false);
        GoodJob.gameObject.SetActive(false);

        // Accumulate correct objects for TrafficLight
        totalCorrectObjects += CountCorrectObjects(ObjectName.Barier);
        totalRequiredObjects += something.GetNumberOfObjects(ObjectName.Barier);

        // Accumulate correct objects for SpeedBump
        totalCorrectObjects += CountCorrectObjects(ObjectName.Bus);
        totalRequiredObjects += something.GetNumberOfObjects(ObjectName.Bus);

        totalCorrectObjects += CountCorrectObjects(ObjectName.Ambulance);
        totalRequiredObjects += something.GetNumberOfObjects(ObjectName.Ambulance);

        // Now check if total correct objects match the total required objects
        if (totalCorrectObjects == totalRequiredObjects)
        {
            GoodJob.gameObject.SetActive(true);
            //resetButton.isTimerGoing = false;
            TryAgain.gameObject.SetActive(false);
        }
        else
        {
            TryAgain.gameObject.SetActive(true);
            GoodJob.gameObject.SetActive(false);
        }
    }

    private int CountCorrectObjects(ObjectName type)
    {
        int correctCount = 0;
        foreach (var obj in something.GetGrabObjects(type))
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
