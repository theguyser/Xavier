using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public TalkToScript talkToScript;
    public GameObject dialogueOptions;
    public TextMeshProUGUI dialogue1;
    public TextMeshProUGUI dialogue2;
    public TextMeshProUGUI dialogue3;

    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {

        //Debug.Log("Starting conversation with " + dialogue.name);
        dialogueBox.SetActive(true);
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        nameText.text = dialogue.name;
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
        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);

        dialogueText.text = sentence;
    }
    public void DisplayDialogueOptions(Dialogue dialogue)
    {
        dialogueOptions.SetActive(true);
        dialogue1.text = dialogue.DialogueOptions[0];
        dialogue2.text = dialogue.DialogueOptions[1];
        dialogue3.text = dialogue.DialogueOptions[2];
        EndDialogue();
    }
    public void EndDialogue()
    {
        //Debug.Log("End of conversation");
        talkToScript.inConversation = false;
        talkToScript.canStartConversation = true;
        sentences.Clear();
        dialogueBox.SetActive(false);
    }
}
