using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Dialogue
{
    [TextArea(1, 5)]
    public string[] names;
    [TextArea(3, 10)]
    public string[] sentences;
    [TextArea(3, 10)]
    public string[] DialogueOptions;
}
