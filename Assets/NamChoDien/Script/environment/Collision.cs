using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject runAnim;
    
    public static bool isCollided = false;
    private void Start()
    {
        isCollided = false;
        thePlayer = GameObject.Find("Player");
        runAnim = GameObject.Find("RunningAnimation");
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isCollided = true;
            // Log the name of the colliding object for debugging
            Debug.Log("Collision detected with: " + other.name);

            // Disable the BoxCollider of this GameObject
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            // Disable the movement script in thePlayer GameObject
            thePlayer.GetComponent<movement>().enabled = false;

            // Additional debug log to confirm the script is disabled
            if (!thePlayer.GetComponent<movement>().enabled)
            {
                Debug.Log("Movement script has been disabled on the player.");
            }

            //Run falling down animation
            runAnim.GetComponent<Animator>().Play("Stumble Backwards");
            //Button.SetActive(true);
            //GameOverText.SetActive(true);
            
            //Run game over scene
        }


    }


       
}
