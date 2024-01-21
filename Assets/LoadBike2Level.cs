using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBike2Level : MonoBehaviour
{
    public GameObject button;
    public void LoadBike2LevelScene()
    {
        SceneManager.LoadScene("easier subway surfer");

    }
    private void Start()
    {
        button.SetActive(false);
    }
    private void Update()
    {
        if (StartDialogue.startingDialougueComplete)
        {
            
            button.SetActive(true);
        }

    }
}
