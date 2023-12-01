using System;
using UnityEngine;

public class Grabber : MonoBehaviour {

    private GameObject selectedObject;
    
    private Boolean canSnap = false;
    private Vector3 snapPosition;
    private float offset;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if(selectedObject == null) {
                RaycastHit hit = CastRay();

                if(hit.collider != null) {
                    if (!hit.collider.CompareTag("drag")) {
                        return;
                    }

                    selectedObject = hit.collider.gameObject;
                    Cursor.visible = false;
                    for (int i = 0; i < gameManager.grabObject.Length; i++)
                    {
                        if (selectedObject == gameManager.grabObject[i])
                        {
                            offset = gameManager.grabObjectOffset[i];
                        }
                    }
                }
            } else {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                
                selectedObject.transform.position = new Vector3(worldPosition.x, offset, worldPosition.z);
                

                selectedObject = null;
                Cursor.visible = true;
                if (canSnap)
                {

                    transform.position = snapPosition;
                    Debug.Log(this.name + " Snapped to " + snapPosition);

                }
            }
        }

        if(selectedObject != null) {
            
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            float what = 0.25f;
            what+=offset;
            selectedObject.transform.position = new Vector3(worldPosition.x, what, worldPosition.z);

            if (Input.GetMouseButtonDown(1)) {
                selectedObject.transform.rotation = Quaternion.Euler(new Vector3(
                    selectedObject.transform.rotation.eulerAngles.x,
                    selectedObject.transform.rotation.eulerAngles.y + 90f,
                    selectedObject.transform.rotation.eulerAngles.z));
            }
        }
    }

    private RaycastHit CastRay() {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("snap"))
        {
            Debug.Log(other.name + " and " + this.name + " collided");
            canSnap = true;
            snapPosition = other.transform.position;
            Debug.Log("Snap position is " + snapPosition);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("snap"))
        {
            Debug.Log(other.name + " and " + this.name + " no longer colliding");
            canSnap = false;
        }
    }
}
