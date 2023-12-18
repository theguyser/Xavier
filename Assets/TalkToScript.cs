using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToScript : MonoBehaviour
{
    
    public static bool canStartConversation = true;
    public static GameObject talkTarget = null;
    public bool DialogueOptionsAvailable = false;
    public Dialogue dialogue;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(!canStartConversation)
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence(dialogue);
                Debug.Log("Displaying Next Sentence");
                return;
            }
            else
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null && hit.collider.gameObject == gameObject && canStartConversation)
                {
                    talkTarget = hit.collider.gameObject;
                    StartConversation();
                }
            }
        }
    }
    private RaycastHit CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit);
        return hit;
    }
    private void StartConversation()
    {
        canStartConversation = false;
        //TalkManager.SelectObject(gameObject);
        Debug.Log("Starting Conversation");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }
}
