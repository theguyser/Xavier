using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject ButtonTop;
    public GameObject ButtonMiddle;
    public GameObject ButtonBottom;
    private int correctDialogueOption;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonTopPressed()
    {
        Debug.Log("Button Top Pressed");
        ButtonTop.SetActive(false);
        ButtonMiddle.SetActive(false);
        ButtonBottom.SetActive(false);
        if(correctDialogueOption == 0)
        {
            Debug.Log("Correct Dialogue Option");
            TalkToScript.isCorrectFollowUp = true;
            TalkToScript.isIncorrectFollowUp = false;
        }
        else
        {

            Debug.Log("Incorrect Dialogue Option");
            TalkToScript.isIncorrectFollowUp = true;
            TalkToScript.isCorrectFollowUp = false;
        }
    }
    public void ButtonMiddlePressed()
    {
        Debug.Log("Button Middle Pressed");
        ButtonTop.SetActive(false);
        ButtonMiddle.SetActive(false);
        ButtonBottom.SetActive(false);
        if(correctDialogueOption == 1)
        {
            Debug.Log("Correct Dialogue Option");
            TalkToScript.isCorrectFollowUp = true;
            TalkToScript.isIncorrectFollowUp = false;
        }
        else
        {
            Debug.Log("Incorrect Dialogue Option");
            TalkToScript.isIncorrectFollowUp = true;
            TalkToScript.isCorrectFollowUp = false;
        }
    }
    public void ButtonBottomPressed()
    {
        Debug.Log("Button Bottom Pressed");
        ButtonTop.SetActive(false);
        ButtonMiddle.SetActive(false);
        ButtonBottom.SetActive(false);
        if(correctDialogueOption == 2)
        {
            Debug.Log("Correct Dialogue Option");
            TalkToScript.isCorrectFollowUp = true;
            TalkToScript.isIncorrectFollowUp = false;
        }
        else
        {
            Debug.Log("Incorrect Dialogue Option");
            TalkToScript.isIncorrectFollowUp = true;
            TalkToScript.isCorrectFollowUp = false;
        }
    }
    public void SetCorrectDialogueOption(int correctButton)
    {
        this.correctDialogueOption = correctButton;
    }
}
