using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRoad2 : MonoBehaviour
{
    //public bool startingdialoguecomplete = false;
    public GameObject button;
    public Winner Winner;
    public GameObject text;
    public GameObject TryAgain;
    public GameObject reset;
    public void LoadRoad2Dialogue()
    {
        SceneManager.LoadScene("Road Level 2 Start Dialogue");

    }
    private void Start()
    {
        text.SetActive(false);
        reset.SetActive(false);
        button.SetActive(false);
        TryAgain.SetActive(false);
    }
    private void Update()
    {
        if (Winner.completedLevel)
        {
            //Debug.Log("Starting dialogue complete");
            //startingdialoguecomplete = true;
            text.SetActive(true);
            button.SetActive(true);
        }
        if (Collision.isCollided)
        {
            TryAgain.SetActive(true);
            reset.SetActive(true);
        }

    }
}
