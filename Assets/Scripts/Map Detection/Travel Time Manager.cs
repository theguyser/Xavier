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
            
            { "Station2toStation3", 8f },
            //Blue route
            { "Station1toStation5", 4f },
            { "Station1toStation6", 7.4f },
            { "Station1toStation7", 12.7f },
            { "Station1toStation3.2", 17.7f },
            //Blue + Orange
            { "Station3.2toStation4", 20.7f },
        };

        // Example usage: SetTravelTime("Station1toStation2");
    }

    public void SetTravelTime(string stationPair)
    {
        if (travelTimeBetweenStations.TryGetValue(stationPair, out float travelTime))
        {
            Debug.Log("travel time: " + travelTime);
            //totalTravelTime = totalTravelTime + travelTime;
            travelTimeText.text = "Travel Time: " + travelTime.ToString("F1") + " min";
            Debug.Log("TTT: " + totalTravelTime);
        }
    }

    // Other methods...
}