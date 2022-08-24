using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    [SerializeField] private float dialogueRange;
    [SerializeField] private LayerMask playerLayer;
    private bool playerHit;

    [SerializeField] private DialogueSettings dialogue;

    private List<string> sentences = new List<string>();

    private void Start() 
    {
        GetNPCInfo();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) &&playerHit) 
        {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }

    private void GetNPCInfo()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DialogueControl.instance.languages)
            {
                case DialogueControl.idiom.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;

                case DialogueControl.idiom.eng:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;

                case DialogueControl.idiom.spa:
                    sentences.Add(dialogue.dialogues[i].sentence.spanish);
                    break;

                default:
                    sentences.Add(dialogue.dialogues[i].sentence.english);      
                    break;
            }

        }
    }

    private void FixedUpdate()
    {
        ShowDialogue();
    }

    private void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
