using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRoadLevel1 : MonoBehaviour
{
    public bool startingdialoguecomplete = false;
    public GameObject button;

    public void LoadRoadScene()
    {
        SceneManager.LoadScene("[Lan] Road Level 1");

    }
    private void Start()
    {
        button.SetActive(false);
    }
    private void Update()
    {
        if (StartDialogue.startingDialougueComplete)
        {
            Debug.Log("Starting dialogue complete");
            startingdialoguecomplete = true;
            button.SetActive(true);
        }
        else if(startingdialoguecomplete)
        {
            button.SetActive(true);
            Debug.Log("button activated?");
            Debug.Log(button.name);
        }
        else
        {
            
        }
    }
}
