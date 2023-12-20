using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private Dialogue dialogue;
    private GameObject correctTalkTarget;

    void Start()
    {
        correctTalkTarget  = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && TalkToScript.talkTarget!=null)
        {
            Debug.Log("Mouse Button Down "+ TalkToScript.talkTarget);
            if (!TalkToScript.canStartConversation && TalkToScript.talkTarget==correctTalkTarget)
            {
                //FindObjectOfType<DialogueManager>().DisplayNextSentence(dialogue); moved to dialogue trigger
                DisplayNextSentence(dialogue);
                //Debug.Log("Displaying Next Sentence");
                return;
            }
            else if(TalkToScript.canStartConversation && TalkToScript.talkTarget==correctTalkTarget)
            {
                //FindObjectOfType<DialogueManager>().StartDialogue(dialogue); moved to dialogue trigger
                TriggerDialogue(dialogue);
                //Debug.Log("Starting Dialogue");
                return;
            }
            else if(TalkToScript.talkTarget!=correctTalkTarget)
            {
                //Debug.Log("Not the correct talk target");
                return;
            }
            
        }
    }
    
    public void ReceiveDialogueFromScript(Dialogue dialogue)
    {
        this.dialogue = dialogue;

    }
    public void TriggerDialogue(Dialogue dialogue)
    {
        TalkToScript.canStartConversation = false;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    public void DisplayNextSentence(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence(dialogue);
    }
}
