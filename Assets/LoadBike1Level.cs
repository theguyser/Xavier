using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBike1Level : MonoBehaviour
{
    //public bool startingdialoguecomplete = false;
    public GameObject button;

    public void LoadBike1LevelScene()
    {
        SceneManager.LoadScene("subwaysurfer");

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
            //startingdialoguecomplete = true;
            button.SetActive(true);
        }

    }
}
