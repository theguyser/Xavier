using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoadLevel2EndScript : MonoBehaviour
{
    public GameObject button;
    [SerializeField] TextMeshProUGUI GoodJob;
    public GameObject reset;
    public GameObject check;

    public void LoadRoadLV2EndScene()
    {
        SceneManager.LoadScene("Road Level 2 End Dialogue");

    }
    private void Start()
    {
        button.SetActive(false);
    }
    private void Update()
    {
        if (GoodJob.IsActive())
        {
            reset.SetActive(false);
            check.SetActive(false);
            button.SetActive(true);
        }
        else
        {
            Debug.Log("Null");
        }

    }
}
