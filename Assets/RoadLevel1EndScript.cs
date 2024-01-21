using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RoadLevel1EndScript : MonoBehaviour
{
    public GameObject button;
    [SerializeField] TextMeshProUGUI GoodJob;

    public void LoadRoadLV1EndScene()
    {
        SceneManager.LoadScene("Road Level 1 End Dialogue");

    }
    private void Start()
    {
        button.SetActive(false);
    }
    private void Update()
    {
        if (GoodJob.IsActive())
        {
            
            button.SetActive(true);
        }
        
    }
}
