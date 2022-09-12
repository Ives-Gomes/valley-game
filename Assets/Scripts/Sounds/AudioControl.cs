using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField] private AudioClip bmgMusic;

    private AudioManager audioM;

    private void Start()
    {
        audioM = FindObjectOfType<AudioManager>();

        audioM.PlayeBGM(bmgMusic);
    }
}
