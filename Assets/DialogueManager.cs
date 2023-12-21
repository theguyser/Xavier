using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<string> names;
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI NameDisplayedOnDialogueBox;
    //public TalkToScript talkToScript;
    public GameObject DialogueOptions;
    public GameObject[] DialogueOptionButtons = new GameObject[3];
    public GameObject StartingDialogue;
    /*public TextMeshProUGUI DialogueOption1;
    public TextMeshProUGUI DialogueOption2;
    public TextMeshProUGUI DialogueOption3;*/
    private bool startingDialougueComplete = false;
    private bool buttonPressed = false;

    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }
    private void Update()
    {
        buttonPressed = FindAnyObjectByType<ButtonManager>().buttonPressed;
        if(buttonPressed)
        {
            Debug.Log("Button Pressed: " + buttonPressed);
        }
    }
    public void StartDialogue(Dialogue dialogue, Dialogue correctFollowUp, Dialogue incorrectFollowUp)
    {
        //Debug.Log("Starting conversation with " + InitialDialogue.name);
        dialogueBox.SetActive(true);
        sentences.Clear();
        names.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            
            sentences.Enqueue(sentence);
            
        }
        
        foreach (string name in dialogue.names)
        {
            
            names.Enqueue(name);
            
        }
        DisplayNextSentence(dialogue, correctFollowUp, incorrectFollowUp);
    }

    public void DisplayNextSentence(Dialogue dialogue, Dialogue correctFollowUp, Dialogue incorrectFollowUp)
    {
        if (sentences.Count == 0 && !TalkToScript.isFollowUpConversation)
        {
            //Debug.Log("End of conversation");
            //dialogueOptions.SetActive(true);
            DisplayDialogueOptions(dialogue, correctFollowUp, incorrectFollowUp);
            return;

        }
        else if (sentences.Count == 0 && TalkToScript.isFollowUpConversation)
        {
            Debug.Log("why is sentence count 0?");
            //dialogueOptions.SetActive(true);
            EndDialogue();
            return;

        }
        //string name = names.Dequeue();

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        //dialogueText.text = sentence; (Before Typing Effect)
        //Debug.Log("Count" + ": " + sentences.Count);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        NameDisplayedOnDialogueBox.text = name;
        //Debug.Log(name+": "+sentence);
    }
    public void DisplayDialogueOptions(Dialogue dialogue, Dialogue correctFollowUp, Dialogue incorrectFollowUp)
    {
        if(dialogue.DialogueOptions == null)
        {
            EndDialogue();
            return;
        }
        else if (dialogue.DialogueOptions.Length == 0)
        {
            EndDialogue();
            return;
        }
        DialogueOptions.SetActive(true);
        for (int i = 0; i < dialogue.DialogueOptions.Length; i++)
        {
            DialogueOptionButtons[i].SetActive(true);
            DialogueOptionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = dialogue.DialogueOptions[i];
            if (DialogueOptionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text == "")
            {
                DialogueOptionButtons[i].SetActive(false);
            }
        }
        
        FindObjectOfType<ButtonManager>().ReceiveDialogueFromScript(correctFollowUp, incorrectFollowUp);
    }
    public void DisplayFollowUpDialogue(Dialogue correctFollowUp, Dialogue incorrectFollowUp)
    {
        if(correctFollowUp == null || incorrectFollowUp == null)
        {
            EndDialogue();
            return;
        }
        else
        {
            FindAnyObjectByType<ButtonManager>().buttonPressed = false;
            DialogueOptions.SetActive(false);
            dialogueBox.SetActive(true);
            
            if (TalkToScript.isCorrectFollowUp == true)
            {
                foreach (string sentence in correctFollowUp.sentences)
                {

                    sentences.Enqueue(sentence);

                }

                foreach (string name in correctFollowUp.names)
                {

                    names.Enqueue(name);

                }
            }
            else if (TalkToScript.isIncorrectFollowUp == true)
            {
                foreach (string sentence in incorrectFollowUp.sentences)
                {

                    sentences.Enqueue(sentence);

                }

                foreach (string name in incorrectFollowUp.names)
                {

                    names.Enqueue(name);

                }
            }
            Debug.Log("Displaying Follow Up Dialogue" + sentences);
            DisplayNextSentence(null, correctFollowUp, incorrectFollowUp);
        }   
        
    }
    public void EndDialogue()
    {
        //Debug.Log("End of conversation");
        if (startingDialougueComplete == false)
        {
            FindObjectOfType<StartDialogue>().StartingDialogueComplete();
            startingDialougueComplete = true;
            
        }
        
        TalkToScript.canStartConversation = true;
        TalkToScript.talkTarget = null;
        TalkToScript.isFollowUpConversation = false;
        sentences.Clear();
        names.Clear();
        dialogueBox.SetActive(false);
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
    }

    
    IEnumerator WaitUntil(bool condition, Dialogue dialogue, Dialogue correctFollowUp, Dialogue incorrectFollowUp)
    {
        while (!condition)
        {
            Debug.Log("Waiting");
            yield return new WaitUntil(()=>condition);
            
        }
        Debug.Log("After While Loop");
        
        DisplayFollowUpDialogue(correctFollowUp, incorrectFollowUp);
    }
    
}
