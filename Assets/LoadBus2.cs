using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadBus2 : MonoBehaviour
{
    public GameObject button;
    public TextMeshProUGUI text;

    public void LoadBus2Scene()
    {
        SceneManager.LoadScene("Bus2");

    }
    private void Start()
    {
        button.SetActive(false);
    }
    private void Update()
    {
        
        if (text.IsActive())
        {
            Debug.Log("Starting dialogue complete");
            //startingdialoguecomplete = true;
            button.SetActive(true);
        }

    }
}
