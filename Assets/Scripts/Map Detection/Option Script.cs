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

    

}
