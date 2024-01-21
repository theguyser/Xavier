using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    public void LoadRoadScene()
    {
        SceneManager.LoadScene("Road Level 1 Start Dialogue");

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
