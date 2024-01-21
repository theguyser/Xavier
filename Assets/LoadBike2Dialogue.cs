using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBike2Dialogue : MonoBehaviour
{
    public GameObject nextLevelButton;

    public void LoadBike2StartDialogue()
    {
        SceneManager.LoadScene("Bike 2 Dialogue Start");

    }
    private void Start()
    {
        nextLevelButton.SetActive(false);
    }
    private void Update()
    {
        if (StartDialogue.startingDialougueComplete)
        {
            
            nextLevelButton.SetActive(true);
        }

    }
}
