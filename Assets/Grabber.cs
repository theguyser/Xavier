using System;
using UnityEngine;

public class Grabber : MonoBehaviour {

    private GameObject selectedObject;
    private Boolean canSnap = false;
    private Vector3 snapPosition;
    [SerializeField] private float offset;

    private void Start()
    {
        Debug.Log(this.offset+this.name);
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
                }
            } else {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                
                selectedObject.transform.position = new Vector3(worldPosition.x, this.offset, worldPosition.z);
                Debug.Log("after setting position " + this.offset+this.name);
                selectedObject = null;
                Cursor.visible = true;
                if(canSnap)
                {
                    transform.position = snapPosition;

                }
            }
        }

        if(selectedObject != null) {
            Debug.Log("before settings position " + this.offset + this.name);
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            float what = this.offset+1f;
            Debug.Log(what+this.name);
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
            canSnap = true;
            snapPosition = other.transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("snap"))
        {
            canSnap = false;
        }
    }
}
