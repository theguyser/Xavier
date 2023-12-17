using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TalkToScript;

public class StartDialogue : MonoBehaviour
{
    private bool canStart = true;
    public Dialogue dialogue;
    public static bool startingDialougueComplete = false;
    
    void Start()
    {
        
        StartConversation();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!canStart)
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence(dialogue);
                return;
            }
        }
        else if (startingDialougueComplete)
        {
            return;
        }
    }
    private void StartConversation()
    {
        canStart = false;
        //TalkManager.SelectObject(gameObject);
        FindObjectOfType<DialogueManager>().StartFirstConversation(dialogue);

    }
    public void StartingDialogueComplete()
    {
        startingDialougueComplete = true;
    }
}
