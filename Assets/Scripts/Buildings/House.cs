using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private int woodAmount;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float timeAmount;

    [Header("Components")]
    [SerializeField] private GameObject houseColl;
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private Transform point;
    
    private bool detectingPlayer;
    private float timeCount;
    private bool isBegining;

    private Player player;
    private PlayerItems playerItems;
    private PlayerAnim playerAnim;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        playerAnim = player.GetComponent<PlayerAnim>();
        playerItems = player.GetComponent<PlayerItems>();
    }

    private void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E)
            && playerItems.TotalWood >= woodAmount)
        {
            isBegining = true;

            playerAnim.OnHammeringStarted();

            houseSprite.color = startColor;

            player.transform.position = point.position;

            player.IsPaused = true;

            playerItems.TotalWood -= woodAmount;
        }

        if (isBegining)
        {
            timeCount += Time.deltaTime;

            if (timeCount >= timeAmount)
            {
                playerAnim.OnHammeringEnded();

                houseSprite.color = endColor;

                player.IsPaused = false;

                houseColl.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
