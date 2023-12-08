using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerMovement PlayerMoveScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            Debug.Log("Player is on the ground");
            //PlayerMoveScript.playerongrnd = true;
            PlayerMoveScript.SetPlayerGroundCheck(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            Debug.Log("Player is not on the ground");
            //PlayerMoveScript.playerongrnd = false;
            PlayerMoveScript.SetPlayerGroundCheck(false);
        }
    }
}
