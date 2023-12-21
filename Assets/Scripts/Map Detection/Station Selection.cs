using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class StationSelection : MonoBehaviour
{
    private GameObject background;
    [SerializeField] GameObject[] routeOptions; // Array of buttons for each route
    [SerializeField] private List<string> connectedRoutes; // Manually assign in Inspector
    private Image backgroundImage;
    private Button buttonComponent;
    private Image buttonImage;
    private Text textComponent;
    [SerializeField] private TravelTimeManager travelTimeManager;
    private RaycastHit hit;
    private float timeOnRouteOrange = 0f;
    private static float timeOnRouteBlue ;
    private float timeSpent;

    private void Start()
    {
        background = GameObject.Find("Background");
        if (background == null)
        {
            Debug.LogError("Background not found");
        }
        //Disable the Image Component of the background
        backgroundImage = background.GetComponent<Image>();
        if (backgroundImage != null)
        {
            backgroundImage.enabled = false;
        }

        GameObject[] unsortedOptions = GameObject.FindGameObjectsWithTag("option");
        routeOptions = unsortedOptions.OrderBy(go => go.name).ToArray();
        //routeOptions = GameObject.FindGameObjectsWithTag("option");
        if (routeOptions == null || routeOptions.Length == 0)
        {
            Debug.LogError("Route options not found");
        }
        // Disable the Button and Text components of each route option
        foreach (var option in routeOptions)
        {
            buttonComponent = option.GetComponent<Button>();
            buttonImage = option.GetComponent<Image>();
            textComponent = option.GetComponentInChildren<Text>();

            if (buttonComponent != null)
            {
                buttonComponent.enabled = false;
            }

            if (textComponent != null)
            {
                textComponent.enabled = false;
            }

            if (buttonImage != null)
            {
                buttonImage.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = CastRay();
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                ShowOptions();
                Debug.Log("Hit: " + hit.collider.gameObject);
                if (OptionScript.onRouteOrange == true)
                {
                    RouteOrange();
                }
                else if (OptionScript.onRouteBlue == true)
                {
                    RouteBlue();
                }
                
            }
        }

        timeSpent = timeOnRouteBlue + timeOnRouteOrange;
    }

    private void ShowOptions()
    {
        
        // Activate background and deactivate all route options initially
        backgroundImage.enabled = true;
           
        foreach (var option in routeOptions)
        {
            buttonComponent = option.GetComponent<Button>();
            buttonImage = option.GetComponent<Image>();
            textComponent = option.GetComponentInChildren<Text>();

            if (buttonComponent != null)
            {
                buttonComponent.enabled = false;
            }

            if (textComponent != null)
            {
                textComponent.enabled = false;
            }

            if (buttonImage != null)
            {
                buttonImage.enabled = false;
            }
        }
        
        // Activate the buttons for the connected routes
        foreach (string route in connectedRoutes)
        {
            int routeIndex;
            if (int.TryParse(route, out routeIndex) && routeIndex >= 0 && routeIndex < routeOptions.Length)
            {
                buttonImage = routeOptions[routeIndex].GetComponent<Image>();
                buttonImage.enabled = true;
                
                buttonComponent = routeOptions[routeIndex].GetComponent<Button>();
                buttonComponent.enabled = true;
                
                textComponent = routeOptions[routeIndex].GetComponentInChildren<Text>();
                textComponent.enabled = true;
                
            }
        }
        // Debugging: Log connected routes
        Debug.Log("Connected Routes: " + string.Join(", ", connectedRoutes));
    }


    private RaycastHit CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit);
        return hit;
    }

    private void RouteOrange()
    {
       
        if (hit.collider.tag == "Station 2")
            {
                if (travelTimeManager != null)
                {
                    travelTimeManager.SetTravelTime("Station1toStation2");
                    
                }
                else
                {
                    Debug.LogError("TravelTimeManager reference not set in StationSelection.");
                }
            }
            else if (hit.collider.tag == "Station 3")

            {
                if (travelTimeManager != null)
                {
                    travelTimeManager.SetTravelTime("Station1toStation3");
                    
                }
                else
                {
                    Debug.LogError("TravelTimeManager reference not set in StationSelection.");
                }
            }
            else if (hit.collider.tag == "Station 4" && timeSpent == 0)

            {
                if (travelTimeManager != null)
                {
                    travelTimeManager.SetTravelTime("Station1toStation4");
                    Debug.Log("Time one Blue: " + timeSpent);
                }
                else
                {
                    Debug.LogError("TravelTimeManager reference not set in StationSelection.");
                }
            }
            else if (hit.collider.tag == "Station 4" && timeSpent == 17.7f)

            {
                if (travelTimeManager != null)
                {
                    travelTimeManager.SetTravelTime("Station3.2toStation4");
                }
                else
                {
                    Debug.LogError("TravelTimeManager reference not set in StationSelection.");
                }
            }
    
    }

    private void RouteBlue()
    {
       
        if (hit.collider.tag == "Station 5")
            {
                if (travelTimeManager != null)
                {
                    travelTimeManager.SetTravelTime("Station1toStation5");

                }
                else
                {
                    Debug.LogError("TravelTimeManager reference not set in StationSelection.");
                }
            }
            else if (hit.collider.tag == "Station 6")

            {
                if (travelTimeManager != null)
                {
                    travelTimeManager.SetTravelTime("Station1toStation6");
                }
                else
                {
                    Debug.LogError("TravelTimeManager reference not set in StationSelection.");
                }
            }
            else if (hit.collider.tag == "Station 7")

            {
                if (travelTimeManager != null)
                {
                    travelTimeManager.SetTravelTime("Station1toStation7");

                }
                else
                {
                    Debug.LogError("TravelTimeManager reference not set in StationSelection.");
                }
            }
            else if (hit.collider.tag == "Station 3")

            {
                if (travelTimeManager != null)
                {
                    travelTimeManager.SetTravelTime("Station1toStation3.2");
                    timeOnRouteBlue = 17.7f;

                }
                else
                {
                    Debug.LogError("TravelTimeManager reference not set in StationSelection.");
                }
            }
    }
    
}
