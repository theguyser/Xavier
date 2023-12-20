using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class TextManager : MonoBehaviour
{ 
    public float waitingTimeTotal = 0f;
    // Reference to the Text UI element
    [SerializeField] private TextMeshProUGUI waitingTimeText;
    
    private void UpdateTextUI()
    {
        // Update the text of the TMP UI element
        waitingTimeText.text = "Waiting Time Total: " + waitingTimeTotal.ToString("F1") + "s";
    }
    
    public void Waiting1()
    {
        waitingTimeTotal = waitingTimeTotal + 1f;
        UpdateTextUI();
        Debug.Log("Waiting Time Total: " +  waitingTimeTotal);
    }
    
    public void Waiting2()
    {
        waitingTimeTotal = waitingTimeTotal + 2f;
        UpdateTextUI();
        Debug.Log("Waiting Time Total: " +  waitingTimeTotal);
    }
    
    public void Waiting3()
    {
        waitingTimeTotal = waitingTimeTotal + 3f;
        UpdateTextUI();
        Debug.Log("Waiting Time Total: " +  waitingTimeTotal);
    }
    
    public void Waiting5()
    {
        waitingTimeTotal = waitingTimeTotal + 5f;
        UpdateTextUI();
        Debug.Log("Waiting Time Total: " +  waitingTimeTotal);
    }
}
