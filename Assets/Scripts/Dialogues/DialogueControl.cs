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
    private string[] currentActorName;
    private Sprite[] actorSprite;

    private Player player;

    public static DialogueControl instance;

    public GameObject GetDialogueObj()
    {
        return dialogueObj;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
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

                actorNameText.text = "";

                index = 0;

                dialogueObj.SetActive(false);

                sentences = null;

                isShowing = false;

                player.IsPaused = false;
            }
        }
    }

    public void Speech(string[] txt, string[] actorName, Sprite[] actorProfile)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);

            sentences = txt;

            currentActorName = actorName;

            actorSprite = actorProfile;

            profileSprite.sprite = actorSprite[index];

            actorNameText.text = currentActorName[index];

            StartCoroutine(TypeSentence());

            isShowing = true;

            player.IsPaused = true;
        }
    }
}
