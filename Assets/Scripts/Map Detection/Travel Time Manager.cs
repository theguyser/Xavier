using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelTimeManager : MonoBehaviour
{
    public static bool onRoute5;

    private void Start()
    {
        onRoute5 = false;
    }

    public static void OnRoute5()
    {
        onRoute5 = true;
        Debug.Log("On route 5");
        
    }
    
}
