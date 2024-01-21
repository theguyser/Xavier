using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static int health = 3;
    public GameObject[] hearts;
    public GameObject gameOver;
    public GameObject restartButton;
    //public GameObject quitButton;

    private void Start()
    {
        health = 3;
        gameOver.SetActive(false);
        restartButton.SetActive(false);
        //quitButton.SetActive(false);
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(true);
        }
    }
    private void Update()
    {
        if (health == 2)
        {
            hearts[2].SetActive(false);
        }
        else if (health == 1)
        {
            hearts[1].SetActive(false);
        }
        else if (health == 0)
        {
            hearts[0].SetActive(false);
            gameOver.SetActive(true);
            restartButton.SetActive(true);
           GameObject.Find("Dialogue Box").SetActive(false);
            //quitButton.SetActive(true);
        }
    }

    public void SubtractHealth()
    {
        health--;
    }
}
