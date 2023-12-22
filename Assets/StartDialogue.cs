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
        startingDialougueComplete = false;
        StartConversation();
    }
    private void Update()
    {
        if (startingDialougueComplete)
        {
            return;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            if (!canStart)
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence(dialogue,null,null);
            }
        }

    }
    private void StartConversation()
    {
        canStart = false;
        //TalkManager.SelectObject(gameObject);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue,null,null,false,null);
        TalkToScript.canStartConversation = false;
    }
    public void StartingDialogueComplete()
    {
        TalkToScript.canStartConversation = true;
        startingDialougueComplete = true;
        Destroy(this.gameObject);
    }
}
