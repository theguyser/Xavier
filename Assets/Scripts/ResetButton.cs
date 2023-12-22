using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public TextMeshProUGUI TimeInGame;
    public ButtonScript buttonScript;
    private float sectionCurrentTime;
    public bool isTimerGoing;
    private string timePlaying_Str;
    private TimeSpan timePlaying;
    private void Start()
    {
        if(TimeInGame != null)
        {
            TimeInGame.text = "00:00.0";
            BeginTimer();
        }
        
    }
    private void BeginTimer()
    {
        if (TimeInGame != null)
        {
            isTimerGoing = true;
            StartCoroutine(UpdateTimer());
        }
    }

    IEnumerator UpdateTimer()
    {
        while (isTimerGoing)
        {
            sectionCurrentTime += Time.deltaTime;

            timePlaying = TimeSpan.FromSeconds(sectionCurrentTime);
            timePlaying_Str = timePlaying.ToString("mm':'ss'.'f");
            TimeInGame.text = timePlaying_Str;

            yield return null;
            
        }
        
    }

    public void Reset()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
