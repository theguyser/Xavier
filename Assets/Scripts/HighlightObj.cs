using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selection : MonoBehaviour
{
    public Material highlightMaterial;
    public Material selectionMaterial;

    private Material[] originalMaterialsHighlight;
    private Material[] originalMaterialsSelection;
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;

    void Update()
    {
        // Highlight
        if (highlight != null)
        {
            RestoreMaterials(highlight, originalMaterialsHighlight);
            highlight = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("drag") && highlight != selection)
            {
                MeshRenderer renderer = highlight.GetComponent<MeshRenderer>();
                if (renderer != null && !MaterialsAreEqual(renderer.materials, highlightMaterial))
                {
                    originalMaterialsHighlight = renderer.materials;
                    SetMaterials(renderer, highlightMaterial);
                }
            }
            else
            {
                highlight = null;
            }
        }

        // Selection
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (highlight)
            {
                if (selection != null)
                {
                    RestoreMaterials(selection, originalMaterialsSelection);
                }

                selection = raycastHit.transform;
                MeshRenderer selectionRenderer = selection.GetComponent<MeshRenderer>();
                if (selectionRenderer != null && !MaterialsAreEqual(selectionRenderer.materials, selectionMaterial))
                {
                    originalMaterialsSelection = originalMaterialsHighlight;
                    SetMaterials(selectionRenderer, selectionMaterial);
                }

                highlight = null;
            }
            else
            {
                if (selection)
                {
                    RestoreMaterials(selection, originalMaterialsSelection);
                    selection = null;
                }
            }
        }
    }

    private void SetMaterials(MeshRenderer renderer, Material newMaterial)
    {
        int materialsCount = renderer.materials.Length;
        Material[] newMaterials = new Material[materialsCount];
        for (int i = 0; i < materialsCount; i++)
        {
            newMaterials[i] = newMaterial;
        }

        renderer.materials = newMaterials;
    }

    private void RestoreMaterials(Transform obj, Material[] originalMaterials)
    {
        if (obj == null || originalMaterials == null) return;

        MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderer.materials = originalMaterials;
        }
    }

    private bool MaterialsAreEqual(Material[] materials, Material material)
    {
        foreach (var mat in materials)
        {
            if (mat != material)
            {
                return false;
            }
        }

        return true;
    }
}
