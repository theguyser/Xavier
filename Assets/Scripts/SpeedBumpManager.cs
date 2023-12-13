using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBumpManager : MonoBehaviour
{
    void Start()
    {
        DisableMeshRenderersRecursively(transform);
    }

    void DisableMeshRenderersRecursively(Transform parent)
    {
        // Disable mesh renderers for all children
        foreach (Transform child in parent)
        {
            // Disable the MeshRenderer component if it exists
            MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;
            }

            // Recursively disable mesh renderers for grandchildren
            DisableMeshRenderersRecursively(child);
        }
    }

}
