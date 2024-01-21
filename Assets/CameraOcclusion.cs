using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOcclusion : MonoBehaviour
{
    public Transform target; // Assign your character
    public float thresholdDistance = 1.0f; // Distance at which the character becomes transparent
    private int defaultLayer;
    private int transparentLayer;

    void Start()
    {
        defaultLayer = target.gameObject.layer;
        transparentLayer = LayerMask.NameToLayer("TransparentFX");
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < thresholdDistance)
        {
            target.gameObject.layer = transparentLayer;
        }
        else
        {
            target.gameObject.layer = defaultLayer;
        }
    }
}
