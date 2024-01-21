using UnityEngine;
using System.Collections.Generic;

public class CameraTransparency : MonoBehaviour
{
    public List<Transform> targets; // Assign all your target objects here in the inspector
    public float thresholdDistance; // Distance at which objects become transparent
    private List<int> defaultLayers = new List<int>();
    private int transparentLayer;

    void Start()
    {
        transparentLayer = LayerMask.NameToLayer("Transparent");
        foreach (var target in targets)
        {
            defaultLayers.Add(target.gameObject.layer); // Store the default layer of each object
        }
    }

    void Update()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if (Vector3.Distance(transform.position, targets[i].position) < thresholdDistance)
            {
                targets[i].gameObject.layer = transparentLayer; // Make object transparent
            }
            else
            {
                targets[i].gameObject.layer = defaultLayers[i]; // Revert to original layer
            }
        }
    }
}