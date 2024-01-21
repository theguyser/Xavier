using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BackToTitleScreen : MonoBehaviour
{
    public GameObject button;
    public GameObject reset;
    public Winner winner;
    public GameObject text;
    public void LoadTitleScreen()
    {
        SceneManager.LoadScene("Start Screen");

    }
    void Start()
    {
        reset.SetActive(false);
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (winner.completedLevel)
        {
            text.SetActive(true);
            reset.SetActive(false);
            button.SetActive(true);
        }
    }
}
