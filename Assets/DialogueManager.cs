using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
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

    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);
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
        DisplayNextSentence(dialogue);
    }
    public void StartDialogue(Dialogue dialogue, Dialogue followUpDialogue)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);
        dialogueBox.SetActive(true);
        sentences.Clear();
        names.Clear();
        foreach (string sentence in followUpDialogue.sentences)
        {

            sentences.Enqueue(sentence);

        }

        foreach (string name in followUpDialogue.names)
        {

            names.Enqueue(name);

        }
        DisplayNextSentence(followUpDialogue);
    }

    public void DisplayNextSentence(Dialogue dialogue)
    {
        if (sentences.Count == 0)
        {
            //Debug.Log("End of conversation");
            //dialogueOptions.SetActive(true);
            DisplayDialogueOptions(dialogue);
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
    public void DisplayDialogueOptions(Dialogue dialogue)
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
        //make a coroutine that waits for the player to click a button
        //if the player clicks a button, then call the function that checks if the button is correct
        //if the button is correct, then call the function that starts the correct follow up dialogue
        //if the button is incorrect, then call the function that starts the incorrect follow up dialogue
        //if the player doesn't click a button, then continue to wait for the player to click a button
        StartCoroutine(WaitForButtonPress());
        
        EndDialogue();
    }
    public void DisplayFollowUpDialogue(Dialogue dialogue)
    {
        StartDialogue(dialogue);
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

    IEnumerator WaitForButtonPress()
    {
        yield return new WaitUntil(() => TalkToScript.isCorrectFollowUp == true || TalkToScript.isIncorrectFollowUp == true);
    }
}
