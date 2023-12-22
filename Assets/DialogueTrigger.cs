using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private Dialogue dialogue;
    //private Dialogue followUpDialogue;
    public GameObject correctTalkTarget = null;
    private Dialogue correctFollowUp;
    private Dialogue incorrectFollowUp;
    public int correctDialogueOption;
    private bool canDisplayDialogueOptions = false;

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
            TriggerDialogue(dialogue, correctFollowUp, incorrectFollowUp, canDisplayDialogueOptions, correctTalkTarget);

            return;
        }
        else if (TalkToScript.talkTarget != correctTalkTarget)
        {
            return;
        }
    }
    
    public void ReceiveDialogueFromScript(Dialogue dialogue, Dialogue correctFollowUp, Dialogue incorrectFollowUp, bool canDisplayDialogueOptions)
    {
        this.dialogue = dialogue;
        this.correctFollowUp = correctFollowUp;
        this.incorrectFollowUp = incorrectFollowUp;
        this.canDisplayDialogueOptions = canDisplayDialogueOptions;
        
    }
    public void TriggerDialogue(Dialogue dialogue, Dialogue correctFollowUp, Dialogue incorrectFollowUp, bool canDisplayDialogueOptions, GameObject correctTalkTarget)
    {
        TalkToScript.canStartConversation = false;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, correctFollowUp, incorrectFollowUp, canDisplayDialogueOptions, correctTalkTarget);
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
