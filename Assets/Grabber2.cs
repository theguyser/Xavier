using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber2 : MonoBehaviour
{
    [SerializeField] private float offset;

    private bool canSnap = false;
    private Vector3 snapPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TrySelectOrDropObject();
        }

        if (GrabManager.CurrentlySelectedObject == gameObject)
        {
            if (Input.GetMouseButton(0))
            {
                DragObject();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                TrySnapObject();
            }

            if (Input.GetMouseButtonDown(1))
            {
                RotateObject();
            }
        }
    }

    private void TrySelectOrDropObject()
    {
        RaycastHit hit = CastRay();

        if (hit.collider != null && hit.collider.gameObject == gameObject && GrabManager.CurrentlySelectedObject == null)
        {
            GrabManager.SelectObject(gameObject);
        }
        else if (GrabManager.CurrentlySelectedObject == gameObject)
        {
            GrabManager.DeselectObject();
        }
    }

    private void DragObject()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(worldPosition.x, offset, worldPosition.z);
    }

    private void TrySnapObject()
    {
        if (canSnap)
        {
            transform.position = snapPosition;
        }
        canSnap = false; // Reset the canSnap flag after snapping
    }

    private void RotateObject()
    {
        transform.Rotate(0, 90f, 0);
    }

    private RaycastHit CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit);
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

public static class GrabManager1
{
    public static GameObject CurrentlySelectedObject { get; private set; }

    public static void SelectObject(GameObject obj)
    {
        CurrentlySelectedObject = obj;
    }

    public static void DeselectObject()
    {
        CurrentlySelectedObject = null;
    }
}