using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    Animator anim;
    public GameObject text;
    public Transform pickupHolderPosition;
    public bool canPickUp = false;
    public bool hasObjectInHand = false;
    public GameObject cubeIconUI;
    public bool Epressed = false;
    public int cubeCount = 0;
    

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
            text.SetActive(true);
            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.enabled = false;
            text.SetActive(false);
            canPickUp = false;
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canPickUp && !hasObjectInHand && !Epressed)
        {
            Epressed = true;
            anim.enabled = false;
            text.SetActive(false);
            transform.position = pickupHolderPosition.transform.position;
            transform.SetParent(pickupHolderPosition);
            cubeIconUI.SetActive(true);
            hasObjectInHand = true;
            StartCoroutine(Wait());
        }
        if (Input.GetKeyDown(KeyCode.E) && hasObjectInHand&&!Epressed)
        {
            transform.SetParent(null);
            //transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            cubeIconUI.SetActive(false);
            hasObjectInHand = false;
            Epressed = false;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.01f);
        Epressed = false;
    }
}
