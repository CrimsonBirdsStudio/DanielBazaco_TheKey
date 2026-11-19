using Cinemachine;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    public CinemachineVirtualCamera npcCam;
    public GameObject interactionCanvas;
    public CanvasGroup textCanvasGroup;
    public TextMeshProUGUI dialogueText;
    public Dialogue_SO starterDialogue;

    public float typingSpeed = 0.05f;

    Dialogue_SO currentDialogue;
    bool lastDialogue = false;
    private void Start()
    {
        currentDialogue = starterDialogue;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactionCanvas.activeInHierarchy)
        {
            if (lastDialogue)
            {
                npcCam.Priority = 0;
                textCanvasGroup.alpha = 0;
                currentDialogue = starterDialogue;
                lastDialogue = false;
                return;
            }
            npcCam.Priority = 100;
            textCanvasGroup.alpha = 1;
            StopAllCoroutines();
            StartCoroutine(TypewriterText(currentDialogue.dialogue));
            if (currentDialogue.nextDialogue != null)
            {
                currentDialogue = currentDialogue.nextDialogue;
            }
            else
            {
                lastDialogue = true;
            }
        }
    }

    IEnumerator TypewriterText(string textToDisplay)
    {
        dialogueText.text = textToDisplay;
        dialogueText.maxVisibleCharacters = 0;
        foreach (char c in textToDisplay.ToCharArray())
        {
            dialogueText.maxVisibleCharacters++;
            if (c == '.')
            {
                yield return new WaitForSeconds(typingSpeed * 10);
            }
            else if (c == ',')
            {
                yield return new WaitForSeconds(typingSpeed * 5);
            }
            else
            {
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        interactionCanvas.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        interactionCanvas.SetActive(false);
    }
}
