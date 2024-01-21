using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBus1 : MonoBehaviour
{
    //public bool startingdialoguecomplete = false;
    public GameObject button;

    public void LoadBus1Scene()
    {
        SceneManager.LoadScene("Bus");

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
