using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRoad2Level : MonoBehaviour
{
    
    public GameObject button;

    public void LoadRoad2LevelScene()
    {
        SceneManager.LoadScene("[Lan] Road Testing");

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
            
            button.SetActive(true);
        }
    }
}
