using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBike1 : MonoBehaviour
{
    public GameObject button;
    public TextMeshProUGUI text;

    public void LoadBike1DialogueStartScene()
    {
        SceneManager.LoadScene("Bike 1 Dialogue Start");

    }
    private void Start()
    {
        button.SetActive(false);
    }
    private void Update()
    {
        if (text.IsActive())
        {
            TalkToScript.completedLevel = true;
            Debug.Log("Starting dialogue complete");
            //startingdialoguecomplete = true;
            button.SetActive(true);
        }

    }
}
