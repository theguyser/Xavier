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
            RaycastHit hit = CastRay();
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                ShowOptions();
            }
        }
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
}
