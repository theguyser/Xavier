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
    public GameObject resetButton;
    public GameObject GameOverText;
    public void LoadRoad2Dialogue()
    {
        SceneManager.LoadScene("Road Level 2 Start Dialogue");

    }
    private void Start()
    {
        button.SetActive(false);
        resetButton.SetActive(false);
        GameOverText.SetActive(false);
        //Wait();
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
        else if (Collision.isCollided)
        {
            resetButton.SetActive(true);
            GameOverText.SetActive(true);
        }

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.01f);

        resetButton.SetActive(false);
        Debug.Log("Reset button is " + resetButton);
        GameOverText.SetActive(false);
    }
    
}
