using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerMovespeed;
    private Rigidbody playerRB;
    public float jumpValue = 5f;
    private bool playerongrnd = true;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        float moveStraight = Input.GetAxis("Horizontal") * playerMovespeed * Time.deltaTime;
        float moveSide = Input.GetAxis("Vertical") * playerMovespeed * Time.deltaTime;
        transform.Translate(moveStraight, 0f, moveSide);

        if (Input.GetKeyDown(KeyCode.Space) && playerongrnd)
        {
            playerRB.AddForce(0f, 1f * jumpValue, 0f, ForceMode.Impulse);
        }
    }

    public void SetPlayerGroundCheck(bool thing)
    {
        playerongrnd = thing;
    }
}
