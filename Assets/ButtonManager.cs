using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject ButtonScreen;
    private int correctDialogueOption;
    public bool buttonPressed = false;
    private Dialogue correct;
    private Dialogue incorrect;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReceiveDialogueFromScript(Dialogue correctFollowUp, Dialogue incorrectFollowUp)
    {
        this.correct = correctFollowUp;
        this.incorrect = incorrectFollowUp;
    }
    public void ButtonTopPressed()
    {
        Debug.Log("Button Top Pressed");
        buttonPressed = true;
        ButtonScreen.SetActive(false);
        TalkToScript.isFollowUpConversation = true;
        if(correctDialogueOption == 0)
        {
            Debug.Log("Correct Dialogue Option");
            TalkToScript.isCorrectFollowUp = true;
            TalkToScript.isIncorrectFollowUp = false;
            
            FindObjectOfType<DialogueManager>().DisplayFollowUpDialogue(correct,incorrect);

        }
        else
        {
            
            Debug.Log("Incorrect Dialogue Option");
            TalkToScript.isIncorrectFollowUp = true;
            TalkToScript.isCorrectFollowUp = false;
            FindObjectOfType<HealthManager>().SubtractHealth();
            FindObjectOfType<DialogueManager>().DisplayFollowUpDialogue(correct, incorrect);
        }
    }
    public void ButtonMiddlePressed()
    {
        Debug.Log("Button Middle Pressed");
        buttonPressed = true;
        ButtonScreen.SetActive(false);
        TalkToScript.isFollowUpConversation = true;
        if (correctDialogueOption == 1)
        {
            Debug.Log("Correct Dialogue Option");
            TalkToScript.isCorrectFollowUp = true;
            TalkToScript.isIncorrectFollowUp = false;
            
            FindObjectOfType<DialogueManager>().DisplayFollowUpDialogue(correct, incorrect);
            //Debug.Log("");
        }
        else
        {
            Debug.Log("Incorrect Dialogue Option");
            TalkToScript.isIncorrectFollowUp = true;
            TalkToScript.isCorrectFollowUp = false;
            FindObjectOfType<DialogueManager>().DisplayFollowUpDialogue(correct, incorrect);
            FindObjectOfType<HealthManager>().SubtractHealth();
        }
    }
    public void ButtonBottomPressed()
    {
        Debug.Log("Button Bottom Pressed");
        buttonPressed = true;
        ButtonScreen.SetActive(false);
        TalkToScript.isFollowUpConversation = true;
        if (correctDialogueOption == 2)
        {
            Debug.Log("Correct Dialogue Option");
            TalkToScript.isCorrectFollowUp = true;
            TalkToScript.isIncorrectFollowUp = false;
            
            FindObjectOfType<DialogueManager>().DisplayFollowUpDialogue(correct, incorrect);
        }
        else
        {
            Debug.Log("Incorrect Dialogue Option");
            TalkToScript.isIncorrectFollowUp = true;
            TalkToScript.isCorrectFollowUp = false;
            FindObjectOfType<HealthManager>().SubtractHealth();
            FindObjectOfType<DialogueManager>().DisplayFollowUpDialogue(correct, incorrect);
        }
    }
    public void SetCorrectDialogueOption(int correctButton)
    {
        this.correctDialogueOption = correctButton;
    }
}
