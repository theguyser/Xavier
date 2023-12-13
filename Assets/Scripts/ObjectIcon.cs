using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIcon : MonoBehaviour
{
    [SerializeField]  GameObject instantiateObject;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = CastRay();

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Instantiate(instantiateObject);
                Destroy(this);
            }
        }
    }

    private RaycastHit CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit);
        return hit;
    }
  
        
    
}
