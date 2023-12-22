using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    public void LoadRoadScene()
    {
        SceneManager.LoadScene("Road");

    }
    public void LoadBusScene()
    {
        SceneManager.LoadScene("Bus");
    }
    public void LoadMapDetectionScene()
    {
        SceneManager.LoadScene("Map detection");
    }
    public void LoadSubwaySurferScene()
    {
        SceneManager.LoadScene("subwaysurfer");
    }
}
