using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]

public class Dialogue_SO : ScriptableObject
{
    public int dialogueID;
    public string dialogue;
    public Dialogue_SO nextDialogue;
    public bool endDialogue;
}
