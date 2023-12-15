using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npcscript : MonoBehaviour
{
    Animator npcAnimator;
    private Transform currentPosition;
    public Transform playerPos;
    private bool playerInRange = false;

    void Start()
    {
        npcAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            npcAnimator.enabled = false;
            playerInRange = true;
            currentPosition = transform;
            playerPos = other.transform;
            //transform.LookAt(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            npcAnimator.enabled = true;
            //transform.position = currentPosition.position;
        }
    }
    private void Update()
    {
        if (playerInRange)
        {
            transform.LookAt(playerPos.transform);
        }
        if (!playerInRange)
        {
            transform.position = currentPosition.position;
        }
    }
}
