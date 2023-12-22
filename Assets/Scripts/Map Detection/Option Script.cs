using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionScript : MonoBehaviour
{
    [SerializeField] float waitingTime;
    private Image backgroundImage;
    private Button buttonComponent;
    private Image buttonImage;
    private Text textComponent;
    [SerializeField] GameObject[] routeOptions;
    private GameObject background;
    public static bool onRouteOrange = false;
    public static bool onRouteBlue = false;
    public static bool onRouteGreen = false;

    public void ChooseOption()
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
        
        routeOptions = GameObject.FindGameObjectsWithTag("option");
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
        
        Debug.Log("Waiting Time: " + waitingTime);
        
    }

    public void OnRouteOrange()
    {
        onRouteOrange = true;
        onRouteBlue = false;
        onRouteGreen = false;
        StationSelection.timeSpent += StationSelection.timeOnRouteOrange; // Accumulate time
        Debug.Log("Time spent on Orange route: " + StationSelection.timeSpent);
    }

    public void OnRouteBlue()
    {
        onRouteBlue = true;
        onRouteOrange = false;
        onRouteGreen = false;
        StationSelection.timeSpent += StationSelection.timeOnRouteBlue; // Accumulate time
        Debug.Log("Time spent on Blue route: " + StationSelection.timeSpent);
    }

    public void OnRouteGreen()
    {
        onRouteGreen = true;
        onRouteBlue = false;
        onRouteOrange = false;
        StationSelection.timeSpent += StationSelection.timeOnRouteGreen; // Accumulate time
        Debug.Log("Time spent on Green route: " + StationSelection.timeSpent);
    }
}
