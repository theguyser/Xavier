using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    
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

        charModel.GetComponent<Animator>().Play("Stumble Backwards");
    }
}
