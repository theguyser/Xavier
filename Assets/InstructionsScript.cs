using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if left mouse button is clicked
        //set active to false
        if (Input.GetMouseButtonDown(0))
        {
            this.gameObject.SetActive(false);
        }
    }
}
