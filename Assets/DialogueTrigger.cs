using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private Dialogue dialogue;
    //private Dialogue followUpDialogue;
    private GameObject correctTalkTarget;
    private Dialogue correctFollowUp;
    private Dialogue incorrectFollowUp;
    public int correctDialogueOption;
    

    void Start()
    {
        correctTalkTarget  = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && TalkToScript.talkTarget != null)
        {
            InitialDialogueTrigger();
        }
    }
    private void InitialDialogueTrigger()
    {
        
        if (!TalkToScript.canStartConversation && TalkToScript.talkTarget == correctTalkTarget)
        {
            DisplayNextSentence(dialogue,correctFollowUp,incorrectFollowUp);

        }
        else if (TalkToScript.canStartConversation && TalkToScript.talkTarget == correctTalkTarget)
        {
            SetCorrectButton(correctDialogueOption);
            TriggerDialogue(dialogue, correctFollowUp, incorrectFollowUp);

            return;
        }
        else if (TalkToScript.talkTarget != correctTalkTarget)
        {
            return;
        }
    }
    /*public void FollowUpDialogueTriggger()
    {
        if (!TalkToScript.canStartConversation && TalkToScript.talkTarget == correctTalkTarget)
        {
            DisplayNextSentence(followUpDialogue);
            return;
        }
        else if (TalkToScript.canStartConversation && TalkToScript.talkTarget == correctTalkTarget)
        {
            TriggerDialogue(followUpDialogue);
            return;
        }
        else if (TalkToScript.talkTarget != correctTalkTarget)
        {
            return;
        }
    }*/
    
    public void ReceiveDialogueFromScript(Dialogue dialogue, Dialogue correctFollowUp, Dialogue incorrectFollowUp)
    {
        this.dialogue = dialogue;
        this.correctFollowUp = correctFollowUp;
        this.incorrectFollowUp = incorrectFollowUp;
        //this.followUpDialogue = followUpDialogue;
    }
    /*public void ReceiveFollowUpDialogueFromScript(Dialogue followUpDialogue)
    {
        //this.dialogue = dialogue;
        this.followUpDialogue = followUpDialogue;
    }*/
    public void TriggerDialogue(Dialogue dialogue, Dialogue correctFollowUp, Dialogue incorrectFollowUp)
    {
        TalkToScript.canStartConversation = false;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, correctFollowUp, incorrectFollowUp);
    }
    public void DisplayNextSentence(Dialogue dialogue, Dialogue correctFollowUp, Dialogue incorrectFollowUp)
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence(dialogue, correctFollowUp, incorrectFollowUp);
    }

    public void SetCorrectButton(int correctButton)
    {
        FindObjectOfType<ButtonManager>().SetCorrectDialogueOption(correctButton);
    }
}
