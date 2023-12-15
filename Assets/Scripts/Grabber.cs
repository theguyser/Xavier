using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Networking;

public class Grabber : MonoBehaviour
{
    private bool isDragging = false;
    private bool canSnap = false;
    private GameObject snapTarget = null;
    private Vector3 snapPosition;
    private Collider snapTargetCollider = null;
    private MeshRenderer snapTargetMeshRenderer = null;
    private float originalYPosition; // To store the original Y position
    [SerializeField]  private GameObject allSnapableGameObject;
    [SerializeField] private GameObject objectRemainsCounting;
    private int totalSnapableObjects;
    [SerializeField] private string assetType;

    private void Start()
    {
        originalYPosition = transform.position.y; // Store the original Y position on start
       // Debug.Log("originalYPosition is " + originalYPosition);
        totalSnapableObjects = CountChildren(objectRemainsCounting.transform);
        //Debug.Log("total count " + totalSnapableObjects);
        SnappedObjectManager.RegisterAssetType(assetType);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = CastRay();

            if (hit.collider != null && hit.collider.gameObject == gameObject && !isDragging)
            {
                StartDragging();
            }
            else if (isDragging)
            {
                StopDragging();
            }
        }

        if (isDragging)
        {
            DragObject();
        }

        if (Input.GetMouseButtonDown(1) && isDragging)
        {
            RotateObject();
        }
    }

    private void StartDragging()
    {
        isDragging = true;
        GrabManager1.SelectObject(gameObject);
        if (snapTargetCollider != null)
        {
            snapTargetCollider.enabled = true;
            //turn on mesh renderer
            snapTargetMeshRenderer.enabled = true;
            snapTargetCollider = null;
        }
    }

    private void StopDragging()
    {
        Debug.Log("Can Snap: " + canSnap);
        if (canSnap && snapTarget != null)
        {
            SnapObject();
        }
        isDragging = false;
        GrabManager.DeselectObject();
    }

    private void DragObject()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(worldPosition.x, originalYPosition, worldPosition.z); // Keep the Y position constant
    }
    
    private void SnapObject()
    {
        transform.position = snapPosition;
        canSnap = false;
        snapTargetCollider = snapTarget.GetComponent<Collider>();
        snapTargetMeshRenderer = snapTarget.GetComponent<MeshRenderer>();
        if (snapTargetCollider != null && snapTargetMeshRenderer != null && snapTarget.CompareTag("snap"))
        {
            snapTargetCollider.enabled = false;
            snapTargetMeshRenderer.enabled = false;
            snapTarget.tag = "haveSnapped";
            //Debug.Log("Tag:" + snapTarget.tag);
            SnappedObjectManager.IncrementCount(assetType);
            Debug.Log("Snapped Objects: " + SnappedObjectManager.snappedCounts[assetType]);
            CheckAndDisableLeftoverSpots();
        }
    
        snapTarget = null;
    }
    private void CheckAndDisableLeftoverSpots()
    {
        if (SnappedObjectManager.GetCount(assetType) >= totalSnapableObjects)
        {
            DisableLeftoverSpots();
        }
    }
    private void DisableLeftoverSpots()
    {
        foreach (Transform child in allSnapableGameObject.transform)
        {
            Collider childCollider = child.GetComponent<Collider>();
            MeshRenderer childMeshRenderer = child.GetComponent<MeshRenderer>();

            if (childCollider != null && childMeshRenderer != null && childMeshRenderer.enabled)
            {
                childCollider.enabled = false;
                childMeshRenderer.enabled = false;
            }
        }
        
    }
    private void EnableMeshRenderersRecursively(Transform parent)
    {
        foreach (Transform child in parent)
        {
            MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();
            Collider childCollider = child.GetComponent<Collider>();
            if (meshRenderer != null && child.gameObject.CompareTag("snap"))
            {
                meshRenderer.enabled = true;
                childCollider.enabled = true;
            }
            
        }
    }
    private int CountChildren(Transform parent)
    {
        int count = 0;
        foreach (Transform child in parent)
        {
                count++;
        }
        return count;
    }
    private void RotateObject()
    {
        transform.Rotate(0, 0, 90f);
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
            snapTarget = other.gameObject;
            snapPosition = other.transform.position;
        }
        Debug.Log("Trigger Enter " + canSnap );
        Debug.Log("snap target" + snapTarget);
    }

    private void OnTriggerStay(Collider other)
    {
        if (isDragging && other.gameObject.CompareTag("haveSnapped"))
        {
            other.gameObject.tag = "snap";
            SnappedObjectManager.DecrementCount(assetType);
            CheckAndDisableLeftoverSpots();
            EnableMeshRenderersRecursively(allSnapableGameObject.transform);
        }
        Debug.Log("Trigger stay " + snapTarget);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("haveSnapped"))
        {
            other.gameObject.tag = "snap";
            canSnap = false;
            snapTarget = null;
            EnableMeshRenderersRecursively(allSnapableGameObject.transform);
            
        }
    }
}

public static class GrabManager
{
    public static GameObject CurrentlySelectedObject { get; private set; }

    public static void SelectObject(GameObject obj)
    {
        if (CurrentlySelectedObject != obj)
        {
            DeselectObject();
            CurrentlySelectedObject = obj;
        }
    }

    public static void DeselectObject()
    {
        CurrentlySelectedObject = null;
    }
    
}