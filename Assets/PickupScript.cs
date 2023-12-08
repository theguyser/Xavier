using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    Animator anim;
    public GameObject gameobject;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.enabled = true;
            gameobject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.enabled = false;
            gameobject.SetActive(false);
        }
    }
}
