using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToScript : MonoBehaviour
{
    public bool inConversation = false;
    public bool canStartConversation = true;
    private GameObject talkTarget = null;
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
            if(inConversation)
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
            
            RaycastHit hit = CastRay();

            if (hit.collider != null && hit.collider.gameObject == gameObject && canStartConversation)
            {
                StartConversation();
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
        inConversation = true;
        canStartConversation = false;
        TalkManager.SelectObject(gameObject);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }
    public static class TalkManager
    {
        public static GameObject CurrentlyTalkingToObject { get; private set; }

        public static void SelectObject(GameObject obj)
        {
            if (CurrentlyTalkingToObject != obj)
            {
                DeselectObject();
                CurrentlyTalkingToObject = obj;
            }
        }

        public static void DeselectObject()
        {
            CurrentlyTalkingToObject = null;
        }
    }
}
