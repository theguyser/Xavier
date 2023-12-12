using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public TalkToScript talkToScript;

    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        nameText.text = dialogue.name;
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            //Debug.Log("End of conversation");
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);

        dialogueText.text = sentence;
    }
    public void EndDialogue()
    {
        //Debug.Log("End of conversation");
        talkToScript.inConversation = false;
        talkToScript.canStartConversation = true;
        sentences.Clear();
    }
}
