using System.Collections.Generic;
using UnityEngine;
using TMPro; // Use Text Mesh Pro namespace

public class TravelTimeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI travelTimeText; // Assign in Inspector
    private Dictionary<string, float> travelTimeBetweenStations;
    private float totalTravelTime = 0f;

    private void Start()
    {
        // Initialize the dictionary with travel times between stations.
        travelTimeBetweenStations = new Dictionary<string, float>
        {
            //Orange route
            { "Station1toStation2", 5f },
            {"Station1toStation3",13f},
            {"Station1toStation4",16f},
            {"Station1toStation9",14.5f},
            {"Station3toStation9",14.5f},
            
            { "Station2toStation3", 8f },
            //Blue route
            { "Station1toStation5", 4.5f },
            { "Station1toStation6", 9f },
            { "Station1toStation7", 12.7f },
            { "Station1toStation3.2", 19f },
            //Blue + Orange
            { "Station3.2toStation4", 22f },
            { "Station3.3toStation4", 19f },
            { "Station3.2toStation9", 22f },
            { "Station3.3toStation9", 16f },
            //Green
            { "Station5toStation6", 6f },
            { "Station5toStation8", 9f },
            { "Station5toStation9", 14.5f },
            //Green + Blue
            { "Station6toStation3", 16f },
            //Green + Orange
            { "Station9toStation4", 1f }
        };

        // Example usage: SetTravelTime("Station1toStation2");
    }

    public void SetTravelTime(string stationPair)
    {
        if (travelTimeBetweenStations.TryGetValue(stationPair, out float travelTime))
        {
            
            travelTimeText.text = "Travel Time: " + travelTime.ToString("F1") + " min";
            Debug.Log("TTT: " + totalTravelTime);
        }
        
    }
}