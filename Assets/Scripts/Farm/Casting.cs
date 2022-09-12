using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    [SerializeField] private int percentageToCasting;
    [SerializeField] private GameObject fishPrefab;

    private bool detectingPlayer;
    private PlayerItems playerItems;
    private PlayerAnim playerAnim;

    private void Start()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        playerAnim = playerItems.GetComponent<PlayerAnim>();
    }

    private void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.OnCastingStarted();
        }
    }

    public void OnCasting()
    {
        int randomValue = Random.Range(1, 100);

        if (randomValue <= percentageToCasting)
        {
            float randomNumberForRandomPosition = Random.Range(-2.5f, -1);
            Vector3 randomPosition = new Vector3(randomNumberForRandomPosition, 0, 0);

            Instantiate(fishPrefab, playerAnim.transform.position + randomPosition, Quaternion.identity); 
        }
        else 
        {
            Debug.Log("Não Pescou");
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
