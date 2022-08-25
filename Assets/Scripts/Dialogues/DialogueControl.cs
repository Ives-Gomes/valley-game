using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spa
    }
    public idiom languages;

    [Header("Components")]
    [SerializeField] private GameObject dialogueObj;
    [SerializeField] private Image profileSprite;
    [SerializeField] private Text speechText;
    [SerializeField] private Text actorNameText;

    [Header("Settings")]
    [SerializeField] private float typingSpeed;

    public bool isShowing;
    private int index;
    private string[] sentences;

    public static DialogueControl instance;

    public GameObject GetDialogueObj()
    {
        return dialogueObj;
    }

    private void Awake()
    {
        instance = this;
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;

                speechText.text = "";

                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";

                index = 0;

                dialogueObj.SetActive(false);

                sentences = null;
                
                isShowing = false;
            }
        }
    }

    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);

            sentences = txt;

            StartCoroutine(TypeSentence());

            isShowing = true;
        }
    }
}
