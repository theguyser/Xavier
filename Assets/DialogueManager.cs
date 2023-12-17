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
    public TextMeshProUGUI nameText;
    //public TalkToScript talkToScript;
    public GameObject DialogueOptions;
    public TextMeshProUGUI DialogueOption1;
    public TextMeshProUGUI DialogueOption2;
    public TextMeshProUGUI DialogueOption3;

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
    public void StartFirstConversation(Dialogue dialogue)
    {
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
    public void DisplayNextSentence(Dialogue dialogue)
    {
        if (sentences.Count == 0)
        {
            //Debug.Log("End of conversation");
            //dialogueOptions.SetActive(true);
            DisplayDialogueOptions(dialogue);
            return;
            
        }
        string name = names.Dequeue();
        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        nameText.text = name;
        dialogueText.text = sentence;
    }
    public void DisplayDialogueOptions(Dialogue dialogue)
    {
        if (dialogue.DialogueOptions.Length == 0)
        {
            EndDialogue();
            return;
        }
        DialogueOptions.SetActive(true);
        DialogueOption1.text = dialogue.DialogueOptions[0];
        DialogueOption2.text = dialogue.DialogueOptions[1];
        DialogueOption3.text = dialogue.DialogueOptions[2];
        EndDialogue();
    }
    public void EndDialogue()
    {
        //Debug.Log("End of conversation");
        FindObjectOfType<StartDialogue>().StartingDialogueComplete();
        TalkToScript.canStartConversation = true;
        TalkToScript.talkTarget = null;
        sentences.Clear();
        names.Clear();
        dialogueBox.SetActive(false);
    }
}
