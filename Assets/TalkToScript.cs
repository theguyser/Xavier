using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TalkToScript : MonoBehaviour
{
    
    public static bool canStartConversation = true;
    public static GameObject talkTarget = null;
    public bool DialogueOptionsAvailable = false;
    public Dialogue dialogue;
    public DialogueTrigger dialogueTrigger;
    public Dialogue CorrectFollowUpDialogue;
    public Dialogue IncorrectFollowUpDialogue;
    public static bool isCorrectFollowUp = false;
    public static bool isIncorrectFollowUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit = CastRay();
        if (hit.collider != null && hit.collider.gameObject == gameObject && canStartConversation)
        {
            talkTarget = hit.collider.gameObject;
            dialogueTrigger.ReceiveDialogueFromScript(dialogue);
            //StartConversation();
        }
    }
    private RaycastHit CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit);
        return hit;
    }

}
