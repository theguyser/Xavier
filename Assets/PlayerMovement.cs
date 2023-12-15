using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerMovespeed;
    private Rigidbody playerRB;
    public float jumpValue = 5f;
    public bool playerongrnd = true;
    public AudioClip jumpSound;
    public AudioClip footstepSound;
    private bool isMoving = false;
    public AudioSource audioSource;
    private float moveStraight;
    private float moveSide;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Audiostuff();
    }
    private void Movement()
    {
        moveStraight = Input.GetAxis("Horizontal") * playerMovespeed * Time.deltaTime;
        moveSide = Input.GetAxis("Vertical") * playerMovespeed * Time.deltaTime;
        transform.Translate(moveStraight, 0f, moveSide);
        isMoving = moveStraight != 0 || moveSide != 0;
        if (isMoving)//(isMoving && !audioSource.isPlaying)
        {
            //audioSource.clip = footstepSound;
            //audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.Space) && playerongrnd)
        {
            playerRB.AddForce(0f, 1f * jumpValue, 0f, ForceMode.Impulse);
            //audioSource.PlayOneShot(jumpSound);
        }
    }

    public void SetPlayerGroundCheck(bool thing)
    {
        playerongrnd = thing;
    }

    public void Audiostuff()
    {
        

    }
}
