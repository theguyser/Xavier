using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool womanCorrect = false;
    public bool manCorrect = false;
    public TalkToScript Man;
    public TalkToScript Woman;
    [SerializeField] TextMeshProUGUI GoodJob;
    public GameObject resetButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //womanCorrect = Woman.completedDialogue;
        if (womanCorrect)
        {
            Man.DialogueOptionsAvailable = true;
            Woman.completedDialogue = true;
        }
        if (manCorrect)
        {
            Debug.Log("Good Job!");
            GoodJob.gameObject.SetActive(true);
            resetButton.SetActive(true);
        }
    }
}
