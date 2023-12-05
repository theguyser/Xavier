using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    private float correctObjects = 0;
    [SerializeField] TextMeshProUGUI GoodJob;
    [SerializeField] TextMeshProUGUI TryAgain;
    
    public ResetButton resetButton;
    
    public void Click()
    {
        GoodJob.gameObject.SetActive(false);
        TryAgain.gameObject.SetActive(false);
        //write a for loop that checks if the index of grabObject is the same as snapObject
        //if it is, then print "correct"
        //if it is not, then print "incorrect"
        for (int i = 0; i < gameManager.grabObject.Length; i++)
        {
            if (gameManager.grabObject[i].transform.position == gameManager.snapObject[i].transform.position)
            {
                //Debug.Log("correct");
                correctObjects++;
                
            }
            else
            {
                //Debug.Log("incorrect");
            }
        }
        if (correctObjects == gameManager.grabObject.Length)
        {
            //make GoodJob canvas appear
            GoodJob.gameObject.SetActive(true);
            
            resetButton.isTimerGoing = false;
        }
        else
        {
            //make TryAgain canvas appear
            TryAgain.gameObject.SetActive(true);
        }
        correctObjects = 0;
        
    }
}
