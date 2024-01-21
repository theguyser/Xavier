using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    string currentSceneName;
    Scene currentScene;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;
    }
    public void Reset()
  {
    SceneManager.LoadScene(currentSceneName);
  }
}
