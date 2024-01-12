using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private GameObject thePlayer;
    private GameObject runAnim;
    public GameObject Button;
    private void Start()
    {
        thePlayer = GameObject.Find("Player");
        runAnim = GameObject.Find("RunningAnimation");
        Button = GameObject.Find("ResetButton");
    }
    void OnTriggerEnter(Collider other)
    {
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
        Button.SetActive(true);
        
        //Run game over scene
        
    }
}
